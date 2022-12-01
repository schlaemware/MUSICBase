using System.Threading.Tasks;
using SW.MB.UI.WinUI3.Commands;
using SW.MB.UI.WinUI3.Models.Observables.Abstracts;

namespace SW.MB.UI.WinUI3.ViewModels.Abstracts {
  public abstract class EntityMasterDetailViewModel : BaseViewModel {
    private bool _IsEditMode;
    public ObservableEntity? _Selected;

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

    public ObservableEntity? Selected {
      get => _Selected;
      set {
        if (SetProperty(ref _Selected, value)) {
          SaveCommand.RaiseCanExecuteChanged();
        }
      }
    }

    #region COMMANDS
    public RelayCommand CreateCommand { get; }
    public RelayCommand DeleteCommand { get; }
    public RelayCommand DiscardCommand { get; }
    public RelayCommand SaveCommand { get; }
    #endregion COMMANDS

    #region CONSTRUCTORS
    public EntityMasterDetailViewModel() : base() {
      CreateCommand = new(() => Create(), () => !IsEditMode);
      DeleteCommand = new(() => Delete(), () => IsEditMode);
      DiscardCommand = new(() => Discard(), () => IsEditMode);
      SaveCommand = new(() => Save(), () => Selected != null);
    }
    #endregion CONSTRUCTORS

    protected abstract void Create();
    protected abstract void Delete();
    protected abstract void Discard();
    protected abstract void LoadData();
    protected abstract void Save();
    protected async Task LoadDataAsync() {
      await Task.Factory.StartNew(() => LoadData());
    }
  }
}
