using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.UI.WinUI3.Models;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels {
    public class MandatorsViewModel : ObservableRecipient {
        private ObservableMandator? _SelectedMandator;

        public OrderedObservableCollection<ObservableMandator> MandatorsCollection { get; } = new();

        public ObservableMandator? SelectedMandator {
            get => _SelectedMandator;
            set => SetProperty(ref _SelectedMandator, value);
        }

        #region CONSTRUCTORS
        public MandatorsViewModel() {
            AddSampleData();
        }
        #endregion CONSTRUCTORS

        private void AddSampleData() {
            MandatorsCollection.Add(new ObservableMandator() { Name = "Musikverein Berneck" });
            MandatorsCollection.Add(new ObservableMandator() { Name = "Musikverein Balgach" });
        }
    }
}
