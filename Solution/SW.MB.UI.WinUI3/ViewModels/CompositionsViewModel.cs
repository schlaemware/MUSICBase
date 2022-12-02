using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.UI.WinUI3.Commands;
using SW.MB.UI.WinUI3.Models.GroupLists;
using SW.MB.UI.WinUI3.Models.Observables;
using SW.MB.UI.WinUI3.ViewModels.Abstracts;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class CompositionsViewModel: BaseViewModel {
    private bool _IsEditMode;
    private string? _SearchText;
    private ObservableComposition? _Selected;
    private IEnumerable<ObservableComposition> _Compositions;

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

    public string? SearchText {
      get => _SearchText;
      set {
        if (SetProperty(ref _SearchText, value)) {
          Filter();
        }
      }
    }

    public ObservableCollection<CompositionsGroupList> GroupsCollection { get; } = new();

    public ObservableComposition? Selected {
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
    public CompositionsViewModel() : base() {
      LoadDataAsync();

      CreateCommand = new(() => Create(), () => !IsEditMode);
      DeleteCommand = new(() => Delete(), () => IsEditMode);
      DiscardCommand = new(() => Discard(), () => IsEditMode);
      SaveCommand = new(() => Save(), () => Selected != null);
    }
    #endregion CONSTRUCTORS

    private void Create() {
      ObservableComposition newEntity = new();
      _Compositions.Append(newEntity);
      SearchText = string.Empty;
      Selected = newEntity;
      IsEditMode = true;
    }

    private void Delete() {

    }

    private void Discard() {
      IsEditMode = false;
    }

    private static IEnumerable<CompositionsGroupList> CreateGrouping(IEnumerable<ObservableComposition> compositions) {
      List<CompositionsGroupList> numbers = new() { new('#', compositions.Where(x => x.Title.FirstOrDefault() is char leading && '0' <= leading && leading <= '9')) };
      numbers.AddRange(compositions.Where(x => x.Title.FirstOrDefault() is char leading && (leading < '0' || '9' < leading))
        .GroupBy(x => x.Title.FirstOrDefault()).Select(x => new CompositionsGroupList(x.Key, x)).OrderBy(x => x.Key));

      return numbers;
    }

    private void Filter() {
      IEnumerable<CompositionsGroupList> groups;

      if (string.IsNullOrEmpty(SearchText)) {
        groups = CreateGrouping(_Compositions);
      } else {
        groups = CreateGrouping(_Compositions.Where(x => SearchText.Length >= 3
          ? x.Title.ToLower().Contains(SearchText.ToLower())
          : x.Title.ToLower().StartsWith(SearchText.ToLower())));
      }

      App.Dispatcher.TryEnqueue(() => {
        GroupsCollection.Clear();
        groups.ForEach(x => GroupsCollection.Add(x));
      });
    }

    private void LoadData() {
      _Compositions = App.GetService<ICompositionsDataService>().GetAll().Select(x => new ObservableComposition(x)).OrderBy(x => x.Title);
      Filter();
    }

    private async void LoadDataAsync() {
      await Task.Factory.StartNew(() => LoadData());
    }

    private void Save() {

    }
  }
}
