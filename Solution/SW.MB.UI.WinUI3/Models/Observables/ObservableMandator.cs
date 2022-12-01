using System;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Models.Observables.Abstracts;

namespace SW.MB.UI.WinUI3.Models.Observables {
  public class ObservableMandator: ObservableEntity, IComparable<ObservableMandator> {
    public string? Name { get; set; }

    #region CONSTRUCTORS
    public ObservableMandator() : base() { }

    public ObservableMandator(MandatorRecord record) : base(record) {
      Name = record.Name;
    }
    #endregion CONSTRUCTORS

    public int CompareTo(ObservableMandator? other) {
      if (other == null) {
        return 1;
      }

      return string.Compare(Name, other.Name);
    }
  }
}
