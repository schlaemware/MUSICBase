using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.Models.GroupLists {
  public class CompositionsGroupList: IGrouping<char, ObservableComposition>, IComparable<CompositionsGroupList> {
    private List<ObservableComposition> _CompositionsList;

    public char Key { get; }

    public CompositionsGroupList(char key, IEnumerable<ObservableComposition> items) {
      Key = key;
      _CompositionsList = new List<ObservableComposition>(items);
    }

    public IEnumerator<ObservableComposition> GetEnumerator() {
      return _CompositionsList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return _CompositionsList.GetEnumerator();
    }

    public int CompareTo(CompositionsGroupList? other) {
      if (other == null) {
        return 1;
      }

      return Key.CompareTo(other.Key);
    }
  }
}
