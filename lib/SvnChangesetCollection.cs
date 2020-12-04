using System.Collections.Generic;
using System.Collections.ObjectModel;

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