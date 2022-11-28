using System;
using System.Collections.ObjectModel;

namespace SW.MB.UI.WinUI3.Models {
    public class OrderedObservableCollection<T> : ObservableCollection<T> where T : IComparable<T> {
        public new void Add(T item) {
            foreach (T element in this) {
                if (item.CompareTo(element) < 0) {
                    Insert(IndexOf(element), item);
                    return;
                }
            }

            base.Add(item);
        }
    }
}
