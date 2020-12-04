using Cyotek.Demo.Windows.Forms;
using Cyotek.SvnMigrate.Client.Properties;
using System;
using System.Windows.Forms;

namespace Cyotek.SvnMigrate.Client
{
  internal static class Program
  {
    #region Private Methods

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Program.UpgradeProgramSettingsIfNecessary();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
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

      if (Settings.Default.NeedSettingsUpgrade)
      {
        Settings.Default.Upgrade();
        Settings.Default.NeedSettingsUpgrade = false;
      }
    }

    #endregion Private Methods
  }
}