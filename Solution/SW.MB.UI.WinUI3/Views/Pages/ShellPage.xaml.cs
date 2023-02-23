using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using SW.MB.UI.WinUI3.Extensions;
using SW.MB.UI.WinUI3.Helpers;
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

      App.MainWindow.ExtendsContentIntoTitleBar = true;
      App.MainWindow.SetTitleBar(AppTitleBar);
      App.MainWindow.Activated += MainWindow_Activated;

      //AppTitleBarIcon.Visibility = NavigationViewControl.IsPaneOpen ? Visibility.Visible : Visibility.Collapsed;
      AppTitleBarText.Text = "AppDisplayName".GetLocalizedString();
      AppTitleBarText.Visibility = NavigationViewControl.IsPaneOpen ? Visibility.Visible : Visibility.Collapsed;
    }

    private void OnLoaded(object sender, RoutedEventArgs e) {
      TitleBarHelper.UpdateTitleBar(RequestedTheme);
    }

    private void MainWindow_Activated(object sender, WindowActivatedEventArgs args) {
      string resource = args.WindowActivationState == WindowActivationState.Deactivated ? "WindowCaptionForegroundDisabled" : "WindowCaptionForeground";
      AppTitleBarText.Foreground = (SolidColorBrush)Application.Current.Resources[resource];
    }

    private void NavigationViewControl_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args) {
      AppTitleBar.Margin = new Thickness() {
        Left = sender.CompactPaneLength * (sender.DisplayMode == NavigationViewDisplayMode.Minimal ? 2 : 1),
        Top = AppTitleBar.Margin.Top,
        Right = AppTitleBar.Margin.Right,
        Bottom = AppTitleBar.Margin.Bottom
      };
    }

    private void NavigationViewControl_PaneOpening(NavigationView sender, object args) {
      //AppTitleBarIcon.Visibility = Visibility.Visible;
      AppTitleBarText.Visibility = Visibility.Visible;
    }

    private void NavigationViewControl_PaneClosing(NavigationView sender, NavigationViewPaneClosingEventArgs args) {
      //AppTitleBarIcon.Visibility = Visibility.Collapsed;
      AppTitleBarText.Visibility = Visibility.Collapsed;
    }
  }
}
