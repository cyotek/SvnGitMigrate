using System.Collections.Generic;
using System.Collections.ObjectModel;

// Cyotek Svn2Git Migration Utility

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

namespace Cyotek.SvnMigrate
{
  public class SvnChangesetCollection : Collection<SvnChangeset>
  {
    #region Public Constructors

    public SvnChangesetCollection()
    {
    }

    public SvnChangesetCollection(IEnumerable<SvnChangeset> items)
    {
      foreach (SvnChangeset item in items)
      {
        this.Add(item);
      }
    }

    #endregion Public Constructors

    #region Public Methods

    public void Sort()
    {
      SortHelpers.QuickSort(this.Items, (x, y) => x.Revision.CompareTo(y.Revision));
    }

    #endregion Public Methods
  }
}