using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
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
      AddSampleData();
    }
    #endregion CONSTRUCTORS

    private void AddSampleData() {
      MusiciansCollection.Add(new ObservableMusician() { Firstname = "Hans", Lastname = "Zimmer" });
      MusiciansCollection.Add(new ObservableMusician() { Firstname = "John", Lastname = "Williams" });
      MusiciansCollection.Add(new ObservableMusician() { Firstname = "Johan", Lastname = "de Mey" });
    }
  }
}
