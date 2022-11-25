using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class UsersViewModel: ObservableRecipient {
    private ObservableUser? _SelectedUser;

    public ObservableCollection<ObservableUser> UsersCollection { get; } = new();

    public ObservableUser? SelectedUser {
      get => _SelectedUser;
      set => SetProperty(ref _SelectedUser, value);
    }

    #region CONSTRUCTORS
    public UsersViewModel() {
      AddSampleData();
    }
    #endregion CONSTRUCTORS

    private void AddSampleData() {
      UsersCollection.Add(new ObservableUser { Firstname = "Michael", Lastname = "Schläpfer" });
      UsersCollection.Add(new ObservableUser { Firstname = "Andi", Lastname = "Seitz" });
      UsersCollection.Add(new ObservableUser { Firstname = "Svenja", Lastname = "Wick" });
    }
  }
}
