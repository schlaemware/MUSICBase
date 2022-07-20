using SW.Framework.WPF.ViewModels;

namespace SW.MB.UI.WPF.Desktop.ViewModels {
  public class AppViewModel : ViewModelBase {
    private bool _IsNavigationPanelReduced = Properties.Settings.Default.IsNavigationPanelReduced;

    public ViewModelBase? CurrentModuleModel { get; }

    public bool IsNavigationPanelReduced {
      get => _IsNavigationPanelReduced;
      set {
        if (SetProperty(ref _IsNavigationPanelReduced, value)) {
          Properties.Settings.Default.IsNavigationPanelReduced = value;
        }
      }
    }

    public AppViewModel() {
      
    }
  }
}
