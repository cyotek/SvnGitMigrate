// Cyotek Svn2Git Migration Utility

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.SvnMigrate
{
  public class User
  {
    #region Private Fields

    private string _alternateName;

    private string _emailAddress;

    private string _name;

    #endregion Private Fields

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
      _name = name;
      _emailAddress = emailAddress;
      _alternateName = alternateName;
    }

    #endregion Public Constructors

    #region Public Properties

    public string AlternateName
    {
      get => _alternateName;
      set => _alternateName = value;
    }

    public string EmailAddress
    {
      get => _emailAddress;
      set => _emailAddress = value;
    }

    public string Name
    {
      get => _name;
      set => _name = value;
    }

    #endregion Public Properties

    #region Public Methods

    public override string ToString()
    {
      return !string.IsNullOrEmpty(_emailAddress)
        ? string.Format("{0} <{1}>", _name, _emailAddress)
        : _name;
    }

    #endregion Public Methods
  }
}