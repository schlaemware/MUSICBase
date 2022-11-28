using System;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.Domain.Models.Records;

namespace SW.MB.UI.WinUI3.Models.Observables {
    public class ObservableComposition : ObservableObject, IComparable<ObservableComposition> {
        public string? Title { get; set; }

        public ObservableComposition() { }

        public ObservableComposition(CompositionRecord record) {

        }

        public int CompareTo(ObservableComposition? other) {
            if (other == null) {
                return 1;
            }

            return string.Compare(Title, other.Title);
        }
    }
}
