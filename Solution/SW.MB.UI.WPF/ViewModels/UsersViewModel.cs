using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SW.Framework.WPF;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
  public class UsersViewModel: ViewModel {
    public ObservableCollection<ObservableUser> Users { get; } = new();

    #region CONSTRUCTORS
    public UsersViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      LoadUsers();
    }
    #endregion CONSTRUCTORS

    private void LoadUsers() {
      if (ServiceProvider.GetRequiredService<IUsersService>() is IUsersService service) {
        foreach (UserRecord user in service.GetAll()) {
          Users.Add(new ObservableUser(user));
        }
      }
    }

    private void StoreUsers() {
      if (ServiceProvider.GetService<IUsersService>() is IUsersService service) {
        service.UpdateRange(Users.Select(x => x.ToRecord()).ToArray());
        LoadUsers();
      }
    }
  }
}
