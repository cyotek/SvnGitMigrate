using System;

// Cyotek Svn2Git Migration Utility

// Copyright © 2020-2024 Cyotek Ltd. All Rights Reserved.

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

    public string CommitMessageTemplate { get; set; }

    public string RepositoryPath { get; set; }

    public SvnChangesetCollection Revisions { get; set; }

    public string SvnBasePath { get; set; }

    public Uri SvnUri { get; set; }

    public bool UseExistingRepository { get; set; }

    public string WorkingPath { get; set; }

    #endregion Public Properties
  }
}