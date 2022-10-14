using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SW.Framework.WPF;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
  public class CompositionsViewModel: ViewModel {
    public ObservableCollection<ObservableComposition> Compositions { get; } = new();

    #region CONSTRUCTORS
    public CompositionsViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      LoadCompositions();
    }
    #endregion CONSTRUCTORS

    private void LoadCompositions() {
      if (ServiceProvider.GetService<ICompositionsService>() is ICompositionsService service) {
        Compositions.Clear();
        foreach (CompositionRecord composition in service.GetAll()) {
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
  }
}
