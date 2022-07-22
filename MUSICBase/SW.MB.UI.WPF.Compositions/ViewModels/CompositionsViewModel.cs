using SW.MB.BL.Contracts.Services;

namespace SW.MB.UI.WPF.Compositions.ViewModels {
  public class CompositionsViewModel {
    private readonly ICompositionsDataService _CompositionsDataService;

    public CompositionsViewModel(ICompositionsDataService compositionsDataService) {
      _CompositionsDataService = compositionsDataService;
    }
  }
}
