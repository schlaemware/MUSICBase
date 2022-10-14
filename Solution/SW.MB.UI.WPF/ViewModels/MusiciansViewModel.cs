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
  public class MusiciansViewModel: ViewModelBase {
    private ObservableMusician? _SelectedMusician;

    public ObservableCollection<ObservableMusician> Musicians { get; } = new();

    public ICollectionView MusiciansView { get; }

    public ObservableMusician? SelectedMusician {
      get => _SelectedMusician;
      set => SetProperty(ref _SelectedMusician, value);
    }

    #region CONSTRUCTORS
    public MusiciansViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      IMandatorsService.MandatorChanged += IMandatorsService_MandatorChanged;

      LoadMusicians();

      MusiciansView = CreateView(Musicians);
    }
    #endregion CONSTRUCTORS

    private static ICollectionView CreateView(object source) {
      ICollectionView view = CollectionViewSource.GetDefaultView(source);
      view.SortDescriptions.Add(new SortDescription(nameof(ObservableMusician.Lastname), ListSortDirection.Ascending));
      view.SortDescriptions.Add(new SortDescription(nameof(ObservableMusician.Firstname), ListSortDirection.Ascending));
      view.SortDescriptions.Add(new SortDescription(nameof(ObservableMusician.DateOfBirth), ListSortDirection.Ascending));
      view.SortDescriptions.Add(new SortDescription(nameof(ObservableMusician.ID), ListSortDirection.Ascending));

      return view;
    }

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
