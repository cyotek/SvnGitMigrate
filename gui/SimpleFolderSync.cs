using DotNet.Globbing;
using System.Collections.Specialized;
using System.IO;

// Cyotek Svn2Git Migration Utility

// Copyright © 2020-2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

namespace Cyotek.SvnMigrate.Client
{
  internal static class SimpleFolderSync
  {
    #region Public Methods

    public static void SyncFolders(string src, string dst, StringCollection includeGlobs, StringCollection excludeGlobs)
    {
      Glob[] includes;
      Glob[] excludes;

      includes = GlobMatcher.PrepareGlobs(includeGlobs);
      excludes = GlobMatcher.PrepareGlobs(excludeGlobs);

      SimpleFolderSync.SyncFolders(src, dst, includes, excludes);
    }

    #endregion Public Methods

    #region Private Methods

    private static void CopyNewOrChangedFiles(string src, string dst, Glob[] includes, Glob[] excludes)
    {
      foreach (string srcFile in Directory.EnumerateFiles(src))
      {
        if (GlobMatcher.IsIncluded(srcFile, includes) && !GlobMatcher.IsExcluded(srcFile, excludes))
        {
          string dstFile;
          FileInfo dstInfo;
          FileInfo srcInfo;

          dstFile = Path.Combine(dst, Path.GetFileName(srcFile));
          dstInfo = new FileInfo(dstFile);
          srcInfo = new FileInfo(srcFile);

          if (!dstInfo.Exists || dstInfo.Length != srcInfo.Length || !FileCompare.AreSame(srcFile, dstFile))
          {
            File.Copy(srcFile, dstFile, true);
          }
        }
      }
    }

    private static void CopyNewOrChangedFolders(string src, string dst, Glob[] includes, Glob[] excludes)
    {
      foreach (string srcFolder in Directory.EnumerateDirectories(src))
      {
        if (GlobMatcher.IsIncluded(srcFolder, includes) && !GlobMatcher.IsExcluded(srcFolder, excludes))
        {
          string name;
          string dstFolder;

          name = Path.GetFileName(srcFolder);
          dstFolder = Path.Combine(dst, name);

          if (name != ".svn")
          {
            Directory.CreateDirectory(dstFolder);

            SimpleFolderSync.SyncFolders(srcFolder, dstFolder, includes, excludes);
          }
        }
      }
    }

    private static void DeleteRemovedFiles(string src, string dst)
    {
      foreach (string dstFile in Directory.EnumerateFiles(dst))
      {
        string srcFile;

        srcFile = Path.Combine(src, Path.GetFileName(dstFile));

        if (!File.Exists(srcFile))
        {
          File.Delete(dstFile);
        }
      }
    }

    private static void DeleteRemovedFolders(string src, string dst)
    {
      foreach (string dstFolder in Directory.EnumerateDirectories(dst))
      {
        string name;
        string srcFolder;

        name = Path.GetFileName(dstFolder);
        srcFolder = Path.Combine(src, name);

        if (name != ".git" && !Directory.Exists(srcFolder))
        {
          ShellHelpers.DeletePath(dstFolder);
        }
      }
    }

    private static void SyncFolders(string src, string dst, Glob[] includes, Glob[] excludes)
    {
      SimpleFolderSync.CopyNewOrChangedFiles(src, dst, includes, excludes);
      SimpleFolderSync.CopyNewOrChangedFolders(src, dst, includes, excludes);
      SimpleFolderSync.DeleteRemovedFiles(src, dst);
      SimpleFolderSync.DeleteRemovedFolders(src, dst);
    }

    #endregion Private Methods
  }
}