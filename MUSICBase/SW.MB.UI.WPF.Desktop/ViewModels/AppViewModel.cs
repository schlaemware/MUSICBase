using SW.Framework.WPF.ViewModels;
using SW.MB.BL.Contracts.Services;

namespace SW.MB.UI.WPF.Desktop.ViewModels {
  public class AppViewModel : ViewModelBase {
    private readonly ICompositionsDataService _CompositionsDataService;

    public AppViewModel(ICompositionsDataService compositionsDataService) {
      _CompositionsDataService = compositionsDataService;
    }
  }
}
