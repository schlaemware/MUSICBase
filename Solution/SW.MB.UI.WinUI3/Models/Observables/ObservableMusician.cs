using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.Domain.Models.Records;

namespace SW.MB.UI.WinUI3.Models.Observables {
    public class ObservableMusician: ObservableObject {
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }

    public string? Fullname => $"{Firstname} {Lastname}";

    #region CONSTRUCTORS
    public ObservableMusician() {
      // empty...
    }

    public ObservableMusician(MusicianRecord record) {
      Firstname = record.Firstname;
      Lastname = record.Lastname;
    }
    #endregion CONSTRUCTORS
  }
}
