using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
    public class MusiciansViewModel : ViewModelBase {
        public ObservableCollection<ObservableMusician> Musicians { get; } = new();

        #region CONSTRUCTORS
        public MusiciansViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
            IMandatorsService.MandatorChanged += IMandatorsService_MandatorChanged;
            
            LoadMusicians();
        }
        #endregion CONSTRUCTORS

        private void LoadMusicians() {
            if (ServiceProvider.GetService<IMusiciansService>() is IMusiciansService service) {
                Musicians.Clear();
                
                foreach (MusicianRecord musician in service.GetAll(ActiveMandator?.ToRecord())) {
                    Musicians.Add(new ObservableMusician(musician));
                }
            }
        }

        private void StoreMusicians() {
            if (ServiceProvider.GetService<IMusiciansService>() is IMusiciansService service) {
                service.UpdateRange(Musicians.Select(x => x.ToRecord()).ToArray());
                LoadMusicians();
            }
        }

        #region CALLBACKS
        private void IMandatorsService_MandatorChanged(object? sender, EventArgs e) {
            LoadMusicians();
        }
        #endregion CALLBACKS
    }
}
