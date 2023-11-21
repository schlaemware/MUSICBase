using System.Security;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using SW.MB.UI.WPF.ViewModels.Abstracts;

namespace SW.MB.UI.WPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string? _Username = string.Empty;
        private string? _Password = default;

        public string? Username {
            get => _Username;
            set {
                if (SetProperty(ref _Username, value)) {
                    System.Diagnostics.Debug.WriteLine($"Username: {value}");
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public string? Password {
            get => _Password;
            set {
                if (SetProperty(ref _Password, value)) {
                    System.Diagnostics.Debug.WriteLine($"Password: {value}");
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel() : base()
        {
            LoginCommand = new RelayCommand(LoginCommandExecute, LoginCommandCanExecute);
        }

        private bool LoginCommandCanExecute()
        {
            return !string.IsNullOrEmpty(Username) && Username.Length >= 3
                && Password != null && Password.Length >= 3;
        }

        private void LoginCommandExecute()
        {
            System.Diagnostics.Debug.WriteLine($"LOGIN {Username}: {Password}");
        }
    }
}
