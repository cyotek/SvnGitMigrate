// Cyotek Svn2Git Migration Utility

// Copyright © 2024 Cyotek Ltd. All Rights Reserved.

// Enabling shell styles for the ListView and TreeView controls in C#
// https://devblog.cyotek.com/post/enabling-shell-styles-for-the-listview-and-treeview-controls-in-csharp

// Copyright © 2011 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;
using System.Windows.Forms;

namespace Cyotek.SvnMigrate.Client
{
  internal class ListView : System.Windows.Forms.ListView
  {
    #region Public Methods

    public void CheckAll()
    {
      this.ProcessListItems(li => li.Checked = true);
    }

    public void InvertChecked()
    {
      this.ProcessListItems(li => li.Checked = !li.Checked);
    }

    public void UncheckAll()
    {
      this.ProcessListItems(li => li.Checked = false);
    }

    #endregion Public Methods

    #region Protected Methods

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);

      if (!this.DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
      {
        NativeMethods.SetWindowTheme(this.Handle, "explorer", null);
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void ProcessListItems(Action<ListViewItem> action)
    {
      this.BeginUpdate();

      foreach (ListViewItem item in this.Items)
      {
        action(item);
      }

      this.EndUpdate();
    }

    #endregion Private Methods
  }
}