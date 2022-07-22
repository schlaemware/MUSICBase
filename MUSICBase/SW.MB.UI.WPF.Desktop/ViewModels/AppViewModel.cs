using System.Collections.ObjectModel;
using SW.Framework.WPF.ViewModels;
using SW.MB.BL.Contracts.Services;
using SW.MB.DA.Models.Records;

namespace SW.MB.UI.WPF.Desktop.ViewModels {
    public class AppViewModel : ViewModelBase {
        private readonly ICompositionsDataService _CompositionsDataService;

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

        public ObservableCollection<CompositionRecord> Compositions { get; }

        public AppViewModel(ICompositionsDataService compositionsService) {
            _CompositionsDataService = compositionsService;
            Compositions = new ObservableCollection<CompositionRecord>(_CompositionsDataService.GetAll());
        }
    }
}
