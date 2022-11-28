using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.UI.WinUI3.Models;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels {
    public class CompositionsViewModel : ObservableRecipient {
        public OrderedObservableCollection<ObservableComposition> CompositionsCollection { get; } = new();

        public CompositionsViewModel() {

        }
    }
}
