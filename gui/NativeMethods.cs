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
using System.Runtime.InteropServices;

namespace Cyotek.Windows.Forms
{
  internal static class NativeMethods
  {
    #region Public Fields

    public const int EM_SETCUEBANNER = 5377;

    #endregion Public Fields

    #region Public Methods

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

    #endregion Public Methods
  }
}