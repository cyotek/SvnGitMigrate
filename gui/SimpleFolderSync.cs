using DotNet.Globbing;
using System.Collections.Generic;
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
    #region Private Fields

    private static Dictionary<string, Glob> _globCache = new Dictionary<string, Glob>();

    #endregion Private Fields

    #region Public Methods

    public static void SyncFolders(string src, string dst, StringCollection includeGlobs, StringCollection excludeGlobs)
    {
      Glob[] includes;
      Glob[] excludes;

      includes = SimpleFolderSync.PrepareGlobs(includeGlobs);
      excludes = SimpleFolderSync.PrepareGlobs(excludeGlobs);

      SimpleFolderSync.SyncFolders(src, dst, includes, excludes);
    }

    #endregion Public Methods

    #region Private Methods

    private static void CopyNewOrChangedFiles(string src, string dst, Glob[] includes, Glob[] excludes)
    {
      foreach (string srcFile in Directory.EnumerateFiles(src))
      {
        if (SimpleFolderSync.IsIncluded(srcFile, includes) && !SimpleFolderSync.IsExcluded(srcFile, excludes))
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
        if (SimpleFolderSync.IsIncluded(srcFolder, includes) && !SimpleFolderSync.IsExcluded(srcFolder, excludes))
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

    private static bool IsExcluded(string file, Glob[] globs)
    {
      return globs.Length != 0 && SimpleFolderSync.IsMatch(file, globs);
    }

    private static bool IsIncluded(string file, Glob[] globs)
    {
      return globs.Length == 0 || SimpleFolderSync.IsMatch(file, globs);
    }

    private static bool IsMatch(string file, Glob[] globs)
    {
      bool result;

      result = false;

      if (Path.IsPathRooted(file) && file[1] == ':')
      {
        file = file.Substring(2);
      }

      if (file.IndexOf('\\') != -1)
      {
        file = file.Replace('\\', '/'); // Normalise paths for Unix as there's no option in the glob lib
      }

      for (int i = 0; i < globs.Length; i++)
      {
        if (globs[i].IsMatch(file))
        {
          result = true;
          break;
        }
      }

      return result;
    }

    private static Glob[] PrepareGlobs(StringCollection patterns)
    {
      Glob[] results;

      if (patterns == null || patterns.Count == 0)
      {
        results = new Glob[0];
      }
      else
      {
        results = new Glob[patterns.Count];

        for (int i = 0; i < results.Length; i++)
        {
          string pattern;

          pattern = patterns[i];

          if (!_globCache.TryGetValue(pattern, out Glob instance))
          {
            instance = Glob.Parse(patterns[i]);
            _globCache.Add(pattern, instance);
          }

          results[i] = instance;
        }
      }

      return results;
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