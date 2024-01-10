using System.Windows;
using System.Windows.Input;
using SW.MB.UI.WPF.ViewModels;

namespace SW.MB.UI.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel ViewModel => (LoginViewModel)DataContext;

        public LoginWindow()
        {
            InitializeComponent();

            ViewModel.LoginCommand.PropertyChanged += LoginCommand_PropertyChanged;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void LoginCommand_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName) {
                case nameof(LoginViewModel.LoginCommand.IsRunning):
                    if (!ViewModel.LoginCommand.IsRunning) {
                        LoginPasswordBox.Clear();
                    }
                    break;
            }
        }

        private void LoginPasswordBox_PasswordChanged(object sender, RoutedEventArgs e) {
            ViewModel.Password = LoginPasswordBox.Password;
        }
    }
}
