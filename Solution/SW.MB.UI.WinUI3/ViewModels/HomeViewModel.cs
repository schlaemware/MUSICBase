using System;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Models.Observables;
using SW.MB.UI.WinUI3.ViewModels.Abstracts;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class HomeViewModel: BaseViewModel {
    public string? LoggedInUserName => App.IsUserLoggedIn ? new ObservableUser(App.LoggedInUser!).Fullname : string.Empty;

    public HomeViewModel() {
      App.LoggedInUserChanged += new EventHandler<UserRecord>((_, _) => OnPropertyChanged(nameof(LoggedInUserName)));
    }
  }
}
