using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
  public class MandatorsViewModel: ViewModelBase {
    private ObservableMandator? _SelectedMandator;

    public ObservableCollection<ObservableMandator> Mandators { get; } = new();

    public ObservableMandator? SelectedMandator {
      get => _SelectedMandator;
      set => SetProperty(ref _SelectedMandator, value);
    }

    #region CONSTRUCTORS
    public MandatorsViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      LoadMandators();
    }
    #endregion CONSTRUCTORS

    private void LoadMandators() {
      if (ServiceProvider.GetService<IMandatorsService>() is IMandatorsService service) {
        Mandators.Clear();
        foreach (MandatorRecord mandator in service.GetAll()) {
          Mandators.Add(new ObservableMandator(mandator));
        }
      }
    }

    private void StoreMandators() {
      if (ServiceProvider.GetService<IMandatorsService>() is IMandatorsService service) {
        service.UpdateRange(Mandators.Select(x => x.ToRecord()).ToArray());
        LoadMandators();
      }
    }
  }
}
