using Microsoft.UI.Xaml.Controls;
using SW.MB.UI.WinUI3.ViewModels;

namespace SW.MB.UI.WinUI3.Views.Pages {
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class ShellPage: Page {
    public ShellViewModel ViewModel { get; }

    public ShellPage(ShellViewModel viewModel) {
      ViewModel = viewModel;
      InitializeComponent();

      ViewModel.NavigationService.Frame = NavigationFrame;
      ViewModel.NavigationViewService.Initialize(NavigationViewControl);

      //App.MainWindow.ExtendsContentIntoTitleBar = true;
      //App.MainWindow.SetTitleBar(AppTitleBar);
      //App.MainWindow.Activated += MainWindow_Activated;
      //AppTitleBarText.Text = "";
    }

    private void MainWindow_Activated(object sender, Microsoft.UI.Xaml.WindowActivatedEventArgs args) {
      string resource = args.WindowActivationState == Microsoft.UI.Xaml.WindowActivationState.Deactivated ? "WindowCaptionForegroundDisabled" : "WindowCaptionForeground";

      //AppTitleBarText.Foreground = (SolidColorBrush)App.Current.Resources[resource];
    }
  }
}
