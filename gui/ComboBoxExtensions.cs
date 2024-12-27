// Cyotek Svn2Git Migration Utility

// Copyright © 2024 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using Cyotek.Windows.Forms;
using System.Windows.Forms;

namespace Cyotek.SvnMigrate.Client
{
  internal static class ComboBoxExtensions
  {
    #region Public Methods

    public static void SetCueText(this ComboBox control, string cueText)
    {
      if (control.IsHandleCreated)
      {
        NativeMethods.SendMessage(control.Handle, NativeMethods.CB_SETCUEBANNER, 0, cueText);
      }
    }

    #endregion Public Methods
  }
}