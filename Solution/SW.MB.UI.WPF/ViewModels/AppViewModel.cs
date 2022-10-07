using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SW.Framework.WPF;
using SW.MB.Domain.Contracts;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
  public class AppViewModel : ViewModel {
    public ObservableCollection<ObservableComposition> Compositions { get; } = new();

    #region COMMANDS
    public ICommand StoreCommand { get; }
    #endregion COMMANDS

    #region CONSTRUCTORS
    public AppViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      StoreCommand = new RelayCommand(obj => StoreCompositions());

      LoadCompositions();
    }
    #endregion CONSTRUCTORS

    private void LoadCompositions() {
      ICompositionsService service = ServiceProvider.GetRequiredService<ICompositionsService>();
      foreach (CompositionRecord composition in service.GetAll()) {
        Compositions.Add(new ObservableComposition(composition));
      }
    }

    private void StoreCompositions() {
      ICompositionsService service = ServiceProvider.GetRequiredService<ICompositionsService>();
      service.UpdateRange(Compositions.Select(x => x.ToRecord()).ToArray());
    }
  }
}
