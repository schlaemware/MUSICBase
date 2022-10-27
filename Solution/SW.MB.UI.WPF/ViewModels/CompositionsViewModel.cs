using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
    public class CompositionsViewModel : PageViewModel {
        private MandatorRecord? _Mandator;

        public ObservableCollection<ObservableComposition> Compositions { get; } = new();

        #region CONSTRUCTORS
        public CompositionsViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
            IMandatorsService.MandatorChanged += IMandatorsService_MandatorChanged;
        }
        #endregion CONSTRUCTORS

        protected override void OnIsActiveChanged() {
            base.OnIsActiveChanged();

            if (IsActive) {
                LoadCompositions();
            }
        }

        private void LoadCompositions() {
            if (ServiceProvider.GetService<ICompositionsService>() is ICompositionsService service) {
                Compositions.Clear();

                foreach (CompositionRecord composition in service.GetAll(_Mandator)) {
                    Compositions.Add(new ObservableComposition(composition));
                }
            }
        }

        private void StoreCompositions() {
            if (ServiceProvider.GetService<ICompositionsService>() is ICompositionsService service) {
                service.UpdateRange(Compositions.Select(x => x.ToRecord()).ToArray());
                LoadCompositions();
            }
        }

        #region CALLBACKS
        private void IMandatorsService_MandatorChanged(object? sender, MandatorRecord e) {
            _Mandator = e;

            if (IsActive) {
                LoadCompositions();
            }
        }
        #endregion CALLBACKS
    }
}
