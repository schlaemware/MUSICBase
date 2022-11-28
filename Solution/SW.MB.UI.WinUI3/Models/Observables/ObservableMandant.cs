using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SW.MB.UI.WinUI3.Models.Observables {
    public class ObservableMandant : ObservableObject, IComparable<ObservableMandant> {
        public string? Name { get; set; }

        public int CompareTo(ObservableMandant? other) {
            if (other == null) {
                return 1;
            }

            return string.Compare(Name, other.Name);
        }
    }
}
