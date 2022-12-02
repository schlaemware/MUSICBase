using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.WinUI.UI.Controls.TextToolbarSymbols;
using SW.MB.UI.WinUI3.Commands;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Models.Messages;
using SW.MB.UI.WinUI3.ViewModels.Abstracts;
using Windows.ApplicationModel.Contacts;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class LoginViewModel : BaseViewModel {
    private static string _LoginMessage = "Bitte loggen Sie sich ein.";

    private readonly INavigationService _NavigationService;
    private readonly IPermissionsService _PermissionsService;

    private string _LoginName = string.Empty;
    private string _LoginPassword = string.Empty;
    private bool _StoreLogin;
    private bool _IsLoggingIn;

    public bool IsUserLoggedIn => App.IsUserLoggedIn;

    public string LoginMessage {
      get => _LoginMessage;
      set => SetProperty(ref _LoginMessage, value);
    }

    public string LoginName {
      get => _LoginName;
      set {
        if (SetProperty(ref _LoginName, value)) {
          LoginCommand.RaiseCanExecuteChanged();
        }
      }
    }

    public string LoginPassword {
      get => _LoginPassword;
      set {
        if (SetProperty(ref _LoginPassword, value)) {
          LoginCommand.RaiseCanExecuteChanged();
        }
      }
    }

    public bool StoreLogin {
      get => _StoreLogin;
      set => SetProperty(ref _StoreLogin, value);
    }

    public bool IsLoggingIn {
      get => _IsLoggingIn;
      set => SetProperty(ref _IsLoggingIn, value);
    }

    public Contact? LoggedInUserContact => App.IsUserLoggedIn ? new Contact() {
      FirstName = App.LoggedInUser!.Firstname,
      LastName = App.LoggedInUser!.Lastname,
    } : null;

    public ObservableCollection<string> UserMandators { get; } = new() {
      "Musikverein Balgach",
      "Musikverein Berneck"
    };

    #region COMMANDS
    public RelayCommand LoginCommand { get; }
    #endregion COMMANDS

    #region CONSTRUCTORS
    public LoginViewModel(INavigationService navigationService, IPermissionsService permissionsService) {
      _NavigationService = navigationService;
      _PermissionsService = permissionsService;

      LoginCommand = new RelayCommand(async () => await LoginAsync(),
        () => !string.IsNullOrEmpty(LoginName) && LoginName.Length >= 3 && !string.IsNullOrEmpty(LoginPassword) && LoginPassword.Length >= 3);
    }
    #endregion CONSTRUCTORS

    private void Login() {
      App.Dispatcher.TryEnqueue(() => IsLoggingIn = true);

      if (App.TryLogin(LoginName, LoginPassword, StoreLogin)) {
        // Login successfull...
        App.Dispatcher.TryEnqueue(() => {
          LoginName = string.Empty;
          StoreLogin = false;

          OnPropertyChanged(nameof(IsUserLoggedIn));

          _PermissionsService.EvaluatePermissions();
          Messenger.Send<PermissionsChangedMessage>();

          _NavigationService.NavigateTo(typeof(HomeViewModel).FullName!, null, true);
        });
      } else {
        // Login failed...
        App.Dispatcher.TryEnqueue(() => {
          LoginMessage = "Login fehlgeschlagen!";

          OnPropertyChanged(nameof(LoginMessage));
        });
      }

      App.Dispatcher.TryEnqueue(() => {
        LoginPassword = string.Empty;
        IsLoggingIn = false;
      });
    }

    private async Task LoginAsync() {
      await Task.Factory.StartNew(() => Login());
    }
  }
}
