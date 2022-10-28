﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using SW.Framework.WPF;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
  public class MusiciansViewModel: PageViewModel {
    private MandatorRecord? _Mandator;
    private ObservableMusician? _SelectedMusician;

    public ObservableCollection<ObservableMusician> Musicians { get; } = new();

    public ICollectionView MusiciansView { get; }

    public ObservableMusician? SelectedMusician {
      get => _SelectedMusician;
      set => SetProperty(ref _SelectedMusician, value);
    }

    #region ICOMMANDS
    public ICommand CreateMusicianCommand { get; }
    public ICommand DiscardChangesCommand { get; }
    public ICommand SaveChangesCommand { get; }
    #endregion ICOMMANDS

    #region CONSTRUCTORS
    public MusiciansViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      IMandatorsService.MandatorChanged += IMandatorsService_MandatorChanged;

      MusiciansView = CreateView(Musicians);

      CreateMusicianCommand = new RelayCommand(obj => CreateNewMusician(),
        obj => SelectedMusician?.IsEditMode != true);
      DiscardChangesCommand = new RelayCommand(obj => DiscardChanges(),
        obj => SelectedMusician?.IsEditMode == true);
      SaveChangesCommand = new RelayCommand(obj => StoreMusician(),
        obj => SelectedMusician?.IsEditMode == true);
    }
    #endregion CONSTRUCTORS

    protected override void OnIsActiveChanged() {
      base.OnIsActiveChanged();

      if (IsActive) {
        LoadMusicians();
      }
    }

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

        foreach (MusicianRecord musician in service.GetAll(_Mandator)) {
          Musicians.Add(new ObservableMusician(musician));
        }
      }
    }

    private void CreateNewMusician() {
      SelectedMusician = new ObservableMusician() {
        IsEditMode = true
      };
    }

    private void DiscardChanges() {

    }

    private void StoreMusician() {

    }

    private void StoreMusicians() {
      if (ServiceProvider.GetService<IMusiciansService>() is IMusiciansService service) {
        service.UpdateRange(Musicians.Select(x => x.ToRecord()).ToArray());
        LoadMusicians();
      }
    }

    #region CALLBACKS
    private void IMandatorsService_MandatorChanged(object? sender, MandatorRecord e) {
      _Mandator = e;

      if (IsActive) {
        LoadMusicians();
      }
    }
    #endregion CALLBACKS
  }
}
