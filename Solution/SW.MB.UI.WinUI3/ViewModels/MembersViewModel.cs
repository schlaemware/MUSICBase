using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class MembersViewModel: ObservableRecipient {
    private ObservableMember? _SelectedMember;

    public ObservableCollection<object> MembersCollection { get; } = new();

    public ObservableMember? SelectedMember {
      get => _SelectedMember;
      set => SetProperty(ref _SelectedMember, value);
    }

    #region CONSTRUCTORS
    public MembersViewModel() {
      AddSampleData();
    }
    #endregion CONSTRUCTORS

    private void AddSampleData() {
      MembersCollection.Add(new ObservableMember() { Firstname = "Philipp", Lastname = "Färber" });
      MembersCollection.Add(new ObservableMember() { Firstname = "Andrin", Lastname = "Zimmermann" });
      MembersCollection.Add(new ObservableMember() { Firstname = "Jana", Lastname = "Schläpfer" });
    }
  }
}
