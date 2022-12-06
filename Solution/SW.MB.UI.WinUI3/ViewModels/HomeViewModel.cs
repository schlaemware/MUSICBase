using CommunityToolkit.Mvvm.Messaging;
using SW.MB.UI.WinUI3.Models.Messages;
using SW.MB.UI.WinUI3.ViewModels.Abstracts;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class HomeViewModel: BaseViewModel {
    private string? _LoggedInUserName;

    public string? LoggedInUserName {
      get => _LoggedInUserName;
      set => SetProperty(ref _LoggedInUserName, value);
    }

    #region CONSTRUCTORS
    public HomeViewModel() {
      LoggedInUserName = App.GetService<LoginViewModel>().LoggedInUser?.Fullname;
    }
    #endregion CONSTRUCTORS

    protected override void OnActivated() {
      base.OnActivated();

      Messenger.Register<HomeViewModel, LoggedInUserChangedMessage>(this, (r, m) => r.LoggedInUserName = m.LoggedInUser?.Fullname);
    }
  }
}
