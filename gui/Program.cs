using Cyotek.SvnMigrate.Client.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;

// Cyotek Svn2Git Migration Utility

// Copyright © 2020-2026 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

namespace Cyotek.SvnMigrate.Client
{
  internal static class Program
  {
    #region Private Static Methods

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      UpgradeProgramSettingsIfNecessary();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }

    private static List<string> ToList(StringCollection values)
    {
      List<string> result;

      result = new List<string>();

      if (values != null)
      {
        foreach (string value in values)
        {
          result.Add(value);
        }
      }

      return result;
    }

    /// <summary>Upgrades the application settings, if required.</summary>

    private static void UpgradeProgramSettingsIfNecessary()
    {
      // https://stackoverflow.com/a/13741738/148962

      // Application settings are stored in a subfolder named after the full #.#.#.# version
      // number of the program. This means that when a new version of the program is installed,
      // the old settings will not be available.
      //
      // Fortunately, there's a method called Upgrade() that you can call to upgrade the settings
      // from the old to the new folder.
      //
      // We control when to do this by having a boolean setting called 'NeedSettingsUpgrade' which
      // is defaulted to true. Therefore, the first time a new version of this program is run, it
      // will have its default value of true.
      //
      // This will cause the code below to call "Upgrade()" which copies the old settings to the new.
      // It then sets "NeedSettingsUpgrade" to false so the upgrade won't be done the next time.

      Settings settings = Settings.Default;

      if (settings.NeedSettingsUpgrade)
      {
        settings.Upgrade();
        settings.NeedSettingsUpgrade = false;
        settings.Save();
      }

      // the swap from Newtonsoft to System.Text.Json broke existing
      // files as it doesn't seem to support StringCollection and I
      // didn't want to either add a custom convertor OR have to faff
      // around converting StringCollection to List<string> on the fly.
      // It is a bit of a hack, but I added new IncludeGlobPatterns and
      // ExcludeGlobPatterns settings typed as List<string> and the code
      // uses these instead - so here we have a one time migration to
      // copy values from the old settings to the new
      if (settings.IncludeGlobs != null || settings.ExcludeGlobs != null)
      {
        settings.IncludeGlobPatterns = ToList(settings.IncludeGlobs);
        settings.ExcludeGlobPatterns = ToList(settings.ExcludeGlobs);
        settings.IncludeGlobs = null;
        settings.ExcludeGlobs = null;
        settings.Save();
      }
    }

    #endregion
  }
}
