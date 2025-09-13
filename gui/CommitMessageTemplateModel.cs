// Cyotek Svn2Git Migration Utility

// Copyright © 2024 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;

namespace Cyotek.SvnMigrate.Client
{
  internal sealed class CommitMessageTemplateModel
  {
    #region Public Properties

    public User Author { get; set; }

    public string Log { get; set; }

    public Uri RepositoryUri { get; set; }

    public long Revision { get; set; }

    public DateTime Timestamp { get; set; }

    #endregion Public Properties
  }
}