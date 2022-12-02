using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
    public class BandsViewModel : PageViewModel {
        private MandatorRecord? _Mandator;
        private ObservableBand? _SelectedBand;

        public ObservableCollection<ObservableBand> Bands { get; } = new();

        public ICollectionView BandsView { get; }

        public ObservableBand? SelectedBand {
            get => _SelectedBand;
            set => SetProperty(ref _SelectedBand, value);
        }

        #region CONSTRUCTORS
        public BandsViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
            IMandatorsDataService.MandatorChanged += IMandatorsService_MandatorChanged;

            BandsView = CreateView(Bands);
        }
        #endregion CONSTRUCTORS

        protected override void OnIsActiveChanged() {
            base.OnIsActiveChanged();

            if (IsActive) {
                LoadBands();
            }
        }

        private static ICollectionView CreateView(object source) {
            ICollectionView view = CollectionViewSource.GetDefaultView(source);
            view.SortDescriptions.Add(new SortDescription(nameof(ObservableBand.Name), ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription(nameof(ObservableBand.ID), ListSortDirection.Ascending));

            return view;
        }

        private void LoadBands() {
            if (ServiceProvider.GetService<IBandsDataService>() is IBandsDataService service) {
                Bands.Clear();

                foreach (BandRecord band in service.GetAll()) {
                    Bands.Add(new ObservableBand(band));
                }
            }
        }

        #region CALLBACKS
        private void IMandatorsService_MandatorChanged(object? sender, MandatorRecord e) {
            _Mandator = e;

            if (IsActive) {
                LoadBands();
            }
        }
        #endregion CALLBACKS
    }
}
