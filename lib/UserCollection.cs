using System;
using System.Collections.ObjectModel;

// Cyotek Svn2Git Migration Utility

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

namespace Cyotek.SvnMigrate
{
  public class UserCollection : KeyedCollection<string, User>
  {
    #region Public Methods

    public User Add(string name, string email, string alternateName)
    {
      User user;

      user = new User(name, email, alternateName);

      this.Add(user);

      return user;
    }

    public User Add(string name, string email)
    {
      return this.Add(name, email, null);
    }

    public User GetMapping(string name)
    {
      User result;

      result = null;

      for (int i = 0; i < this.Count; i++)
      {
        User test;

        test = this[i];

        if (string.Equals(name, test.EmailAddress, StringComparison.OrdinalIgnoreCase)
          || string.Equals(name, test.Name, StringComparison.OrdinalIgnoreCase)
          || string.Equals(name, test.AlternateName, StringComparison.OrdinalIgnoreCase))
        {
          result = test;
          break;
        }
      }

      return result;
    }

    #endregion Public Methods

    #region Protected Methods

    protected override string GetKeyForItem(User item)
    {
      return item.EmailAddress;
    }

    #endregion Protected Methods
  }
}