using System.Windows.Controls;
using Local.Framework.WPF.Contracts.ViewModels;
using Local.Framework.WPF.ViewModels;
using SW.MB.BL.Contracts.Services;
using SW.MB.UI.WPF.Compositions.Views.Controls;

namespace SW.MB.UI.WPF.Compositions.ViewModels {
  public class CompositionsViewModel : ExtendedViewModelBase, IModuleViewModel {
    private readonly ICompositionsDataService _CompositionsDataService;

    public UserControl Content { get; } = new CompositionsControl();

    #region CONSTRUCTORS
    public CompositionsViewModel(ICompositionsDataService compositionsDataService) {
      _CompositionsDataService = compositionsDataService;
    }
    #endregion CONSTRUCTORS
  }
}
