using System;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Models.Observables.Abstracts;

namespace SW.MB.UI.WinUI3.Models.Observables {
  public class ObservableMusician: ObservablePerson {
    private DateTime? _DateOfDeath;

    public DateTime? DateOfDeath {
      get => _DateOfDeath;
      set => SetProperty(ref _DateOfDeath, value);
    }

    #region CONSTRUCTORS
    public ObservableMusician() { }

    public ObservableMusician(MusicianRecord record) : base(record) { }
    #endregion CONSTRUCTORS

    public MusicianRecord ToRecord() {
      return new MusicianRecord() {
        ID = ID,
        Created = Created,
        CreatedBy= CreatedBy,
        Updated= Updated,
        UpdatedBy= UpdatedBy,
        Firstname= Firstname,
        Lastname= Lastname,
        DateOfBirth= DateOfBirth,
        DateOfDeath = DateOfDeath,
      };
    }
  }
}
