using System;

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