using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.UI.WinUI3.Models;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class MusiciansViewModel: ObservableRecipient {
    private bool _IsEditMode;
    private ObservableMusician? _SelectedMusician;

    public bool IsEditMode {
      get => _IsEditMode;
      set {
        if (SetProperty(ref _IsEditMode, value)) {

        }
      }
    }

    public OrderedObservableCollection<ObservableMusician> MusiciansCollection { get; } = new();

    public ObservableMusician? SelectedMusician {
      get => _SelectedMusician;
      set {
        if (SetProperty(ref _SelectedMusician, value)) {

        }
      }
    }

    #region COMMANDS

    #endregion COMMANDS

    #region CONSTRUCTORS
    public MusiciansViewModel() {
      LoadDataAsync();
    }
    #endregion CONSTRUCTORS

    private void LoadData() {
      IEnumerable<ObservableMusician> musicians = App.GetService<IMusiciansService>().GetAll().Select(x => new ObservableMusician(x));
      App.Dispatcher.TryEnqueue(() => musicians.ForEach(x => MusiciansCollection.Add(x)));
    }

    private async void LoadDataAsync() {
      await Task.Factory.StartNew(() => LoadData());
    }
  }
}
