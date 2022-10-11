using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables.Abstracts;

namespace SW.MB.UI.WPF.Models.Observables {
  public class ObservableMandator : ObservableEntity {
    public string Name { get; set; }

    #region CONSTRUCTORS
    public ObservableMandator() : base() {
      Name = string.Empty;
    }

    public ObservableMandator(MandatorRecord record) : base(record) {
      Name = record.Name;
    }
    #endregion CONSTRUCTORS

    public MandatorRecord ToRecord() {
      return new MandatorRecord() {
        ID = ID,
        Created = Created,
        CreatedBy = CreatedBy,
        Updated = Updated,
        UpdatedBy = UpdatedBy,
        Name = Name
      };
    }
  }
}
