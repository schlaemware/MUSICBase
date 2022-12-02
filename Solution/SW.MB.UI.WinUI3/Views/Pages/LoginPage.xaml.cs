using Microsoft.UI.Xaml.Controls;
using SW.MB.UI.WinUI3.ViewModels;

namespace SW.MB.UI.WinUI3.Views.Pages {
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class LoginPage: Page {
    public LoginViewModel ViewModel { get; }

    public LoginPage() {
      ViewModel = App.GetService<LoginViewModel>();

      InitializeComponent();
    }
  }
}
