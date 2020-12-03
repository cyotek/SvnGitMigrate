namespace Cyotek.SvnMigrate
{
  public class User
  {
    #region Public Constructors

    public User()
    {
    }

    public User(string name, string emailAddress)
      : this(name, emailAddress, null)
    {
    }

    public User(string name, string emailAddress, string alternateName)
    {
      this.Name = name;
      this.EmailAddress = emailAddress;
      this.AlternateName = alternateName;
    }

    #endregion Public Constructors

    #region Public Properties

    public string AlternateName { get; set; }

    public string EmailAddress { get; set; }

    public string Name { get; set; }

    #endregion Public Properties
  }
}