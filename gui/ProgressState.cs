// Cyotek Svn2Git Migration Utility

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

namespace Cyotek.SvnMigrate.Client
{
  internal class ProgressState
  {
    #region Public Properties

    public SvnChangeset Changeset { get; set; }

    public int Current { get; set; }

    public int Total { get; set; }

    #endregion Public Properties
  }
}