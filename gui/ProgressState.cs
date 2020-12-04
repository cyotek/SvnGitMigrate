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