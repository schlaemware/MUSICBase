using System;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables.Abstracts;

namespace SW.MB.UI.WPF.Models.Observables {
  public class ObservableMusician: ObservablePerson {
    public DateOnly? DateOfDeath { get; set; }

    #region CONSTRUCTORS
    public ObservableMusician() : base() {
      // empty...
    }

    public ObservableMusician(MusicianRecord record) : base(record) {
      DateOfDeath = record.DateOfDeath;
    }
    #endregion CONSTRUCTORS

    public MusicianRecord ToRecord() {
      return new MusicianRecord() {
        ID = ID,
        Created = Created,
        CreatedBy = CreatedBy,
        Updated = Updated,
        UpdatedBy = UpdatedBy,
        Firstname = Firstname,
        Lastname = Lastname,
        DateOfBirth = DateOfBirth,
        DateOfDeath = DateOfDeath,
      };
    }
  }
}
