using SW.MB.UI.WinUI3.Models;
using SW.MB.UI.WinUI3.Models.Observables;
using SW.MB.UI.WinUI3.ViewModels.Abstracts;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class CompositionsViewModel : BaseViewModel {
        public OrderedObservableCollection<ObservableComposition> CompositionsCollection { get; } = new();

        #region CONSTRUCTORS
        public CompositionsViewModel() {

        }
        #endregion CONSTRUCTORS
    }
}
