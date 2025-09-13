// Cyotek Svn2Git Migration Utility

// Copyright © 2024 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;

namespace Cyotek.SvnMigrate.Client
{
  internal partial class RevisionInformationDialog : BaseForm
  {
    #region Public Constructors

    public RevisionInformationDialog()
    {
      this.InitializeComponent();
    }

    public RevisionInformationDialog(SvnChangeset changeset, string data)
      : this()
    {
      revisionTextBox.Text = changeset.Revision.ToString();
      timestampTextBox.Text = changeset.Time.ToString("G");
      authorTextBox.Text = changeset.Author.ToString();
      dataTextBox.Text = data;
    }

    #endregion Public Constructors

    #region Private Methods

    private void CloseButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    #endregion Private Methods
  }
}