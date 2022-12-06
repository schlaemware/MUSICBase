using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.WinUI.UI.Controls.TextToolbarSymbols;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Commands;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Models.Messages;
using SW.MB.UI.WinUI3.Models.Observables;
using SW.MB.UI.WinUI3.ViewModels.Abstracts;
using Windows.ApplicationModel.Contacts;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class LoginViewModel : BaseViewModel {
    private const string _STORED_CREDENTIALS_IDENTIFIER_KEY = "StoredCredentialsIdentifierKey";
    private const string _STORED_CREDENTIALS_PASSWORD_KEY = "StoredCredentialsPasswordKey";

    private static string _LoginMessage = "Bitte loggen Sie sich ein.";

    private readonly INavigationService _NavigationService;
    private readonly IPermissionsService _PermissionsService;

    private ObservableUser? _LoggedInUser;
    private string _LoginIdentifier = string.Empty;
    private string _LoginPassword = string.Empty;
    private bool _StoreLogin;
    private bool _IsLoggingIn;

    public bool IsUserLoggedIn => LoggedInUser != null;

    public ObservableUser? LoggedInUser {
      get => _LoggedInUser;
      set {
        if (SetProperty(ref _LoggedInUser, value)) {
          OnPropertyChanged(nameof(IsUserLoggedIn));
        }
      }
    }

    public Contact? LoggedInUserContact => LoggedInUser is not ObservableUser user ? null : new Contact() {
      FirstName = user.Firstname,
      LastName = user.Lastname,
    };

    public ObservableCollection<string> UserMandators { get; } = new() {
      "Musikverein Balgach",
      "Musikverein Berneck"
    };

    public string LoginMessage {
      get => _LoginMessage;
      set => SetProperty(ref _LoginMessage, value);
    }

    public string LoginIdentifier {
      get => _LoginIdentifier;
      set {
        if (SetProperty(ref _LoginIdentifier, value)) {
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

    #region COMMANDS
    public RelayCommand LoginCommand { get; }
    #endregion COMMANDS

    #region CONSTRUCTORS
    public LoginViewModel(INavigationService navigationService, IPermissionsService permissionsService) {
      _NavigationService = navigationService;
      _PermissionsService = permissionsService;

      LoginCommand = new RelayCommand(async () => await TryLoginAsync(),
        () => !string.IsNullOrEmpty(LoginIdentifier) && LoginIdentifier.Length >= 3 && !string.IsNullOrEmpty(LoginPassword) && LoginPassword.Length >= 3);

      CheckStoredLoginAsync();
    }
    #endregion CONSTRUCTORS

    private async Task CheckStoredLogin() {
      ILocalSettingsService localSettingsService = App.GetService<ILocalSettingsService>();
      string? storedIdentifier = await localSettingsService.ReadSettingAsync<string>(_STORED_CREDENTIALS_IDENTIFIER_KEY);
      string? storedPassword = await localSettingsService.ReadSettingAsync<string>(_STORED_CREDENTIALS_IDENTIFIER_KEY);
      if (!string.IsNullOrEmpty(storedIdentifier) && !string.IsNullOrEmpty(storedPassword)) {
        App.Dispatcher.TryEnqueue(() => {
          LoginMessage = "Automatischer Login...";
          IsLoggingIn = true;
        });
        
        if (App.GetService<IUsersService>().VerifyPassword(storedIdentifier, storedPassword, out UserRecord? loggedInUser)) {
          App.Dispatcher.TryEnqueue(() => {
            LoggedInUser = new ObservableUser(loggedInUser!);
            Messenger.Send(new LoggedInUserChangedMessage(LoggedInUser));

            _PermissionsService.EvaluatePermissions();
            Messenger.Send<PermissionsChangedMessage>();

            _NavigationService.NavigateTo(typeof(HomeViewModel).FullName!, null, true);
            IsLoggingIn = false;
          });
        } else {
          App.Dispatcher.TryEnqueue(() => {
            LoginMessage = "Automatischer Login fehlgeschlagen...";
            IsLoggingIn = false;
          });
        }
      }
    }

    private async void CheckStoredLoginAsync() {
      await Task.Factory.StartNew(async () => await CheckStoredLogin());
    }

    private async void StoreLoginAsync(string identifier, string password) {
      ILocalSettingsService localSettingsService = App.GetService<ILocalSettingsService>();
      await localSettingsService.SaveSettingAsync(_STORED_CREDENTIALS_IDENTIFIER_KEY, identifier);
      await localSettingsService.SaveSettingAsync(_STORED_CREDENTIALS_PASSWORD_KEY, identifier);
    }

    private void TryLogin() {
      App.Dispatcher.TryEnqueue(() => IsLoggingIn = true);

      if (App.GetService<IUsersService>().VerifyPassword(LoginIdentifier, LoginPassword, out UserRecord? loggedInUser)) {
        // Login successfull...
        if (StoreLogin) {
          StoreLoginAsync(LoginIdentifier, LoginPassword);
        }

        App.Dispatcher.TryEnqueue(() => {
          LoginIdentifier = string.Empty;
          LoginPassword = string.Empty;
          StoreLogin = false;

          LoggedInUser = new ObservableUser(loggedInUser!);
          Messenger.Send(new LoggedInUserChangedMessage(LoggedInUser));

          _PermissionsService.EvaluatePermissions();
          Messenger.Send<PermissionsChangedMessage>();

          _NavigationService.NavigateTo(typeof(HomeViewModel).FullName!, null, true);

          IsLoggingIn = false;
        });
      } else {
        // Login failed...
        App.Dispatcher.TryEnqueue(() => {
          LoginPassword = string.Empty;
          LoginMessage = "Login fehlgeschlagen!";

          IsLoggingIn = false;
        });
      }
    }

    private async Task TryLoginAsync() {
      await Task.Factory.StartNew(() => TryLogin());
    }
  }
}
