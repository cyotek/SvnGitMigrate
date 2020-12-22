using System;

// Cyotek Svn2Git Migration Utility

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.SvnMigrate
{
  public class MigrationOptions
  {
    #region Public Properties

    public UserCollection Authors { get; set; } = new UserCollection();

    public string RepositoryPath { get; set; }

    public SvnChangesetCollection Revisions { get; set; }

    public Uri SvnUri { get; set; }

    public bool UseExistingRepository { get; set; }

    public string WorkingPath { get; set; }

    #endregion Public Properties
  }
}