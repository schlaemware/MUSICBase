using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class MusiciansViewModel: ObservableRecipient {
    private ObservableMusician? _SelectedMusician;

    public ObservableCollection<ObservableMusician> MusiciansCollection { get; } = new();

    public ObservableMusician? SelectedMusician {
      get => _SelectedMusician;
      set => SetProperty(ref _SelectedMusician, value);
    }

    #region CONSTRUCTORS
    public MusiciansViewModel() {
      LoadMusiciansAsync();
    }
    #endregion CONSTRUCTORS

    private void LoadMusicians() {
      IEnumerable<MusicianRecord> musicians = App.GetService<IMusiciansService>().GetAll();

      if (!musicians.Any()) {
        musicians = CreateSampleData();
      }

      musicians.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname).ForEach(x => {
          App.Dispatcher.TryEnqueue(() => {
              MusiciansCollection.Add(new ObservableMusician(x));
          });
      });
    }

    private async void LoadMusiciansAsync() {
      await Task.Factory.StartNew(() => LoadMusicians());
    }

    private static List<MusicianRecord> CreateSampleData() {
      return new List<MusicianRecord>() {
        new MusicianRecord() { Firstname = "Hans", Lastname = "Zimmer" },
        new MusicianRecord() { Firstname = "John", Lastname = "Williams" },
        new MusicianRecord() { Firstname = "Johan", Lastname = "de Mey" },
      };
    }
  }
}
