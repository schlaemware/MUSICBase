using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
  public class MandatorsViewModel: ViewModelBase {
    private ObservableMandator? _SelectedMandator;

    public ObservableCollection<ObservableMandator> Mandators { get; } = new();

    public ICollectionView MandatorsView { get; }

    public ObservableMandator? SelectedMandator {
      get => _SelectedMandator;
      set => SetProperty(ref _SelectedMandator, value);
    }

    #region CONSTRUCTORS
    public MandatorsViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      LoadMandators();

      MandatorsView = CreateView(Mandators);
    }
    #endregion CONSTRUCTORS

    private static ICollectionView CreateView(object source) {
      ICollectionView view = CollectionViewSource.GetDefaultView(source);
      view.SortDescriptions.Add(new SortDescription(nameof(ObservableMandator.Name), ListSortDirection.Ascending));
      view.SortDescriptions.Add(new SortDescription(nameof(ObservableMandator.ID), ListSortDirection.Ascending));

      return view;
    }

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
