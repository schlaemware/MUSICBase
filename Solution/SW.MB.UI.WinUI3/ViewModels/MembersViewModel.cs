using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.UI.WinUI3.Models;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels {
    public class MembersViewModel : ObservableRecipient {
        private ObservableMember? _SelectedMember;

        public OrderedObservableCollection<ObservableMember> MembersCollection { get; } = new();

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
            MembersCollection.Add(new ObservableMember() { Firstname = "Sarah", Lastname = "Schläpfer" });
            MembersCollection.Add(new ObservableMember() { Firstname = "Michael", Lastname = "Schläpfer" });
        }
    }
}
