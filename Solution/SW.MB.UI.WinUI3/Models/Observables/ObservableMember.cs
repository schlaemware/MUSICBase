using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Models.Observables.Abstracts;

namespace SW.MB.UI.WinUI3.Models.Observables {
  public class ObservableMember: ObservablePerson {
    public string? Instrument { get; set; }

    #region CONSTRUCTORS
    public ObservableMember() { }

    public ObservableMember(MemberRecord record) : base(record) {
      Instrument = record.Instrument;
    }
    #endregion CONSTRUCTORS

    public MemberRecord ToRecord() {
      return new MemberRecord() {
        ID = ID,
        Created = Created,
        CreatedBy = CreatedBy,
        Updated = Updated,
        UpdatedBy = UpdatedBy,
        Firstname = Firstname ?? string.Empty,
        Lastname = Lastname ?? string.Empty,
        DateOfBirth = DateOfBirth,
        Instrument = Instrument,
      };
    }
  }
}
