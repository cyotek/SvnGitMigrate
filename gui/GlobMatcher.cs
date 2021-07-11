// Cyotek Svn2Git Migration Utility

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using DotNet.Globbing;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace Cyotek.SvnMigrate.Client
{
  internal static class GlobMatcher
  {
    #region Private Fields

    private static readonly Dictionary<string, Glob> _globCache = new Dictionary<string, Glob>();

    #endregion Private Fields

    #region Public Constructors

    static GlobMatcher()
    {
      _globCache = new Dictionary<string, Glob>();
    }

    #endregion Public Constructors

    #region Public Methods

    public static bool IsExcluded(StringCollection files, StringCollection excludeGlobs)
    {
      bool result;
      Glob[] excludes;

      result = false;
      excludes = GlobMatcher.PrepareGlobs(excludeGlobs);

      for (int i = 0; i < files.Count; i++)
      {
        if (GlobMatcher.IsExcluded(files[i], excludes))
        {
          result = true;
          break;
        }
      }

      return result;
    }

    public static bool IsExcluded(string file, Glob[] globs)
    {
      return globs.Length != 0 && GlobMatcher.IsMatch(file, globs);
    }

    public static bool IsIncluded(StringCollection files, StringCollection includeGlobs)
    {
      bool result;
      Glob[] includes;

      result = false;
      includes = GlobMatcher.PrepareGlobs(includeGlobs);

      for (int i = 0; i < files.Count; i++)
      {
        if (GlobMatcher.IsIncluded(files[i], includes))
        {
          result = true;
          break;
        }
      }

      return result;
    }

    public static bool IsIncluded(string file, Glob[] globs)
    {
      return globs.Length == 0 || GlobMatcher.IsMatch(file, globs);
    }

    public static bool IsMatch(string file, Glob[] globs)
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

    public static Glob[] PrepareGlobs(StringCollection patterns)
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

    #endregion Public Methods
  }
}