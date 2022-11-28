using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
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
            LoadDataAsync();
        }
        #endregion CONSTRUCTORS

        private void LoadData() {
            IEnumerable<ObservableMember> members = App.GetService<IMembersService>().GetAll().Select(x => new ObservableMember(x));
            App.Dispatcher.TryEnqueue(() => members.ForEach(x => MembersCollection.Add(x)));
        }

        private async void LoadDataAsync() {
            await Task.Factory.StartNew(() => LoadData());
        }
    }
}
