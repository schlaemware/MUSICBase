using System;
using Microsoft.Extensions.DependencyInjection;
using SW.Framework.WPF;
using SW.MB.Domain.Contracts.Services;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
  public abstract class ViewModelBase : ViewModel {
        private static ObservableMandator? _ActiveMandator;

        public ObservableMandator? ActiveMandator {
            get => _ActiveMandator;
            set {
                if (SetProperty(ref _ActiveMandator, value)) {
                    ServiceProvider.GetService<IMandatorsService>()?.RaiseMandatorChanged();
                }
            }
        }

        #region CONSTRUCTORS
        public ViewModelBase(IServiceProvider serviceProvider) : base(serviceProvider) {

        }
        #endregion CONSTRUCTORS
    }
}
