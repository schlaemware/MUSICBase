using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Models.Observables.Abstracts;

namespace SW.MB.UI.WinUI3.Models.Observables {
  public class ObservableUser: ObservablePerson {
    #region CONSTRUCTORS
    public ObservableUser() { }

    public ObservableUser(UserRecord record) : base(record) { }
    #endregion CONSTRUCTORS
  }
}
