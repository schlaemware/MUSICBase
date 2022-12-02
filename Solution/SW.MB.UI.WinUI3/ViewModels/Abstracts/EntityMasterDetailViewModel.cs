using System;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using SW.MB.UI.WinUI3.Commands;
using SW.MB.UI.WinUI3.Models;
using SW.MB.UI.WinUI3.Models.Observables.Abstracts;

namespace SW.MB.UI.WinUI3.ViewModels.Abstracts {
  public abstract class EntityMasterDetailViewModel<T> : BaseViewModel where T : ObservableEntity, IComparable<T>, new() {
    private bool _IsEditMode;
    public T? _Selected;

    #region PUBLIC PROPERTIES
    public bool IsEditMode {
      get => _IsEditMode;
      set {
        if (SetProperty(ref _IsEditMode, value)) {
          CreateCommand.RaiseCanExecuteChanged();
          DeleteCommand.RaiseCanExecuteChanged();
          DiscardCommand.RaiseCanExecuteChanged();
          SaveCommand.RaiseCanExecuteChanged();
        }
      }
    }

    public OrderedObservableCollection<T> EntitiesCollection { get; } = new();

    public T? Selected {
      get => _Selected;
      set {
        if (SetProperty(ref _Selected, value)) {
          SaveCommand.RaiseCanExecuteChanged();
        }
      }
    }
    #endregion PUBLIC PROPERTIES

    #region PROTECTED PROPERTIES
    #region STRINGS
    protected abstract string DeleteDialogContent { get; }
    protected abstract string DeleteDialogTitle { get; }
    #endregion STRINGS
    #endregion PROTECTED PROPERTIES

    #region COMMANDS
    public RelayCommand CreateCommand { get; }
    public RelayCommand DeleteCommand { get; }
    public RelayCommand DiscardCommand { get; }
    public RelayCommand SaveCommand { get; }
    #endregion COMMANDS

    #region CONSTRUCTORS
    public EntityMasterDetailViewModel() : base() {
      LoadDataAsync().ConfigureAwait(false);

      CreateCommand = new(() => Create(), () => !IsEditMode);
      DeleteCommand = new(() => Delete(), () => IsEditMode);
      DiscardCommand = new(() => Discard(), () => IsEditMode);
      SaveCommand = new(() => Save(), () => Selected != null);
    }
    #endregion CONSTRUCTORS

    protected abstract void LoadData();
    protected abstract void Save();

    protected void Create() {
      T newEntity = new();
      EntitiesCollection.Add(newEntity);
      Selected = newEntity;
      IsEditMode = true;
    }

    protected void Discard() {
      System.Diagnostics.Debug.WriteLine("Discard changes...");
      IsEditMode = false;
    }

    protected async Task LoadDataAsync() {
      await Task.Factory.StartNew(() => LoadData());
    }

    private async void Delete() {
      if (Selected is T entity) {
        ContentDialog deleteDialog = new() {
          Content = DeleteDialogContent,
          Title = DeleteDialogTitle,
          PrimaryButtonText = "Delete",
          CloseButtonText = "Cancel"
        };

        deleteDialog.XamlRoot = App.MainWindow.Content.XamlRoot;
        ContentDialogResult result = await deleteDialog.ShowAsync();

        if (result == ContentDialogResult.Primary) {
          Selected = null;
          EntitiesCollection.Remove(entity);
          Discard();
        }
      }
    }
  }
}
