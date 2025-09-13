using System.Collections.Generic;
using System.IO;

// Cyotek Svn2Git Migration Utility

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

namespace Cyotek.SvnMigrate.Client
{
  internal static class ShellHelpers
  {
    #region Public Methods

    public static void DeleteFiles(string path)
    {
      foreach (string fileName in Directory.EnumerateFiles(path))
      {
        File.SetAttributes(fileName, FileAttributes.Normal);
        File.Delete(fileName);
      }
    }

    public static void DeletePath(string root)
    {
      if (Directory.Exists(root))
      {
        ShellHelpers.EmptyPath(root);

        Directory.Delete(root, true);
      }
    }

    public static void EmptyPath(string root)
    {
      if (Directory.Exists(root))
      {
        Stack<string> paths;

        paths = new Stack<string>();
        paths.Push(root);

        do
        {
          string path;

          path = paths.Pop();

          ShellHelpers.DeleteFiles(path);

          foreach (string child in Directory.EnumerateDirectories(path))
          {
            paths.Push(child);
          }
        } while (paths.Count > 0);
      }
    }

    #endregion Public Methods
  }
}