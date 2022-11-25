using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class MandantsViewModel: ObservableRecipient {
    private ObservableMandant? _SelectedMandant;

    public ObservableCollection<ObservableMandant> MandantsCollection { get; } = new();

    public ObservableMandant? SelectedMandant {
      get => _SelectedMandant;
      set => SetProperty(ref _SelectedMandant, value);
    }

    #region CONSTRUCTORS
    public MandantsViewModel() {
      AddSampleData();
    }
    #endregion CONSTRUCTORS

    private void AddSampleData() {
      MandantsCollection.Add(new ObservableMandant() { Name = "Musikverein Berneck" });
      MandantsCollection.Add(new ObservableMandant() { Name = "Musikverein Balgach" });
    }
  }
}
