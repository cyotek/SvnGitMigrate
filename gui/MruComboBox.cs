// Cyotek Svn2Git Migration Utility

// Copyright © 2024 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Cyotek.SvnMigrate.Client
{
  internal sealed class MruComboBox : ComboBox
  {
    #region Public Methods

    public StringCollection GetMru()
    {
      StringCollection result;

      result = new StringCollection();

      for (int i = 0; i < this.Items.Count; i++)
      {
        result.Add((string)this.Items[i]);
      }

      return result;
    }

    public void LoadMru(StringCollection mru)
    {
      this.Items.Clear();

      if (mru != null)
      {
        this.BeginUpdate();

        foreach (string uri in mru)
        {
          this.Items.Add(uri);
        }

        this.EndUpdate();
      }
    }

    public void UpdateMru()
    {
      string value = this.Text;

      if (!string.IsNullOrWhiteSpace(value))
      {
        int index = this.FindStringExact(value);

        if (index != -1 && index != 0)
        {
          this.Items.RemoveAt(index);
        }

        if (index != 0)
        {
          this.Items.Insert(0, value);
          this.SelectedIndex = 0;
        }

        while (this.Items.Count > 256)
        {
          this.Items.RemoveAt(this.Items.Count - 1);
        }
      }
    }

    #endregion Public Methods

    #region Protected Methods

    protected override void OnLeave(EventArgs e)
    {
      base.OnLeave(e);

      this.UpdateMru();
    }

    #endregion Protected Methods
  }
}