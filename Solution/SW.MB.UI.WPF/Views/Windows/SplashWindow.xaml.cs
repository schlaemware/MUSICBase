using System.Windows;

namespace SW.MB.UI.WPF.Views.Windows {
  /// <summary>
  /// Interaction logic for SplashWindow.xaml
  /// </summary>
  public partial class SplashWindow: Window {
    public SplashWindow() {
      InitializeComponent();
    }

    public void Update(string text) {
      StatusTextBlock.Text = text;
    }
  }
}
