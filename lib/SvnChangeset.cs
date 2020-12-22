using System;

// Cyotek Svn2Git Migration Utility

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.SvnMigrate
{
  public class SvnChangeset
  {
    #region Private Fields

    private User _author;

    private bool _isSelected;

    private string _log;

    private long _revision;

    private DateTime _time;

    #endregion Private Fields

    #region Public Properties

    public User Author
    {
      get => _author;
      set => _author = value;
    }

    public bool IsSelected
    {
      get => _isSelected;
      set => _isSelected = value;
    }

    public string Log
    {
      get => _log;
      set => _log = value;
    }

    public long Revision
    {
      get => _revision;
      set => _revision = value;
    }

    public DateTime Time
    {
      get => _time;
      set => _time = value;
    }

    #endregion Public Properties

    #region Public Methods

    public override string ToString()
    {
      return string.Format("Revision: {0}, Time: {1}, Author: {2}, Log: {3}", _revision, _time, _author?.Name, _log);
    }

    #endregion Public Methods
  }
}