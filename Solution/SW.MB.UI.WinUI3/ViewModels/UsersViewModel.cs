using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.UI.WinUI3.Models;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels {
    public class UsersViewModel : ObservableRecipient {
        private ObservableUser? _SelectedUser;

        public OrderedObservableCollection<ObservableUser> UsersCollection { get; } = new();

        public ObservableUser? SelectedUser {
            get => _SelectedUser;
            set => SetProperty(ref _SelectedUser, value);
        }

        #region CONSTRUCTORS
        public UsersViewModel() {
            LoadDataAsync();
        }
        #endregion CONSTRUCTORS

        private void LoadData() {
            IEnumerable<ObservableUser> users = App.GetService<IUsersService>().GetAll().Select(x => new ObservableUser(x));
            App.Dispatcher.TryEnqueue(() => users.ForEach(x => UsersCollection.Add(x)));
        }

        private async void LoadDataAsync() {
            await Task.Factory.StartNew(() => LoadData());
        }
    }
}
