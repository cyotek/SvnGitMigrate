using System.IO;

// Cyotek Svn2Git Migration Utility

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.SvnMigrate.Client
{
  internal static class SimpleFolderSync
  {
    #region Public Methods

    public static void SyncFolders(string src, string dst)
    {
      SimpleFolderSync.CopyNewOrChangedFiles(src, dst);
      SimpleFolderSync.CopyNewOrChangedFolders(src, dst);
      SimpleFolderSync.DeleteRemovedFiles(src, dst);
      SimpleFolderSync.DeleteRemovedFolders(src, dst);
    }

    #endregion Public Methods

    #region Private Methods

    private static void CopyNewOrChangedFiles(string src, string dst)
    {
      foreach (string srcFile in Directory.EnumerateFiles(src))
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

    private static void CopyNewOrChangedFolders(string src, string dst)
    {
      foreach (string srcFolder in Directory.EnumerateDirectories(src))
      {
        string name;
        string dstFolder;

        name = Path.GetFileName(srcFolder);
        dstFolder = Path.Combine(dst, name);

        if (name != ".svn")
        {
          Directory.CreateDirectory(dstFolder);

          SimpleFolderSync.SyncFolders(srcFolder, dstFolder);
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

    #endregion Private Methods
  }
}