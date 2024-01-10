using System.Text.RegularExpressions;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using SW.MB.UI.WPF.ViewModels.Abstracts;

namespace SW.MB.UI.WPF.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private string? _UserInput = string.Empty;
        private string? _Password = string.Empty;

        public string? UserInput {
            get => _UserInput;
            set {
                if (SetProperty(ref _UserInput, value)) {
                    LoginCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public string? Password {
            get => _Password;
            set {
                if (SetProperty(ref _Password, value)) {
                    LoginCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public IAsyncRelayCommand LoginCommand { get; }

        #region CONSTRUCTORS
        public LoginViewModel() : base()
        {
            LoginCommand = new AsyncRelayCommand(LoginCommandExecute, LoginCommandCanExecute);
        }
        #endregion CONSTRUCTORS

        [GeneratedRegex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        private static partial Regex ValidateMailRegex();

        /// <summary>
        /// String must have at least 3 characters validation.
        /// </summary>
        /// <remarks>
        /// Username must have at least 3 characters.
        /// </remarks>
        /// <returns></returns>
        [GeneratedRegex("[A-Za-z0-9]{3,}")]
        private static partial Regex AtLeastThreeCharactersRegex();

        private bool LoginCommandCanExecute()
        {
            return !string.IsNullOrEmpty(UserInput) && !string.IsNullOrEmpty(Password)
                && (UserInput.Contains('@') ? ValidateMailRegex().IsMatch(UserInput) : AtLeastThreeCharactersRegex().IsMatch(UserInput))
                && AtLeastThreeCharactersRegex().IsMatch(Password);
        }

        private async Task LoginCommandExecute()
        {
            await Task.Delay(3000);
            System.Diagnostics.Debug.WriteLine($"LOGIN {UserInput}: {Password}");
        }        
    }
}
