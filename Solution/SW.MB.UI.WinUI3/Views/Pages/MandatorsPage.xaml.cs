using Microsoft.UI.Xaml.Controls;
using SW.MB.UI.WinUI3.ViewModels;

namespace SW.MB.UI.WinUI3.Views.Pages {
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MandatorsPage: Page {
    public MandatorsViewModel ViewModel { get; }

    #region CONSTRUCTORS
    public MandatorsPage() {
      ViewModel = App.GetService<MandatorsViewModel>();
      InitializeComponent();
    }
    #endregion CONSTRUCTORS
  }
}
