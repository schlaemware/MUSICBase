using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
  public class UsersViewModel: ViewModelBase {
    private ObservableUser? _SelectedUser;

    public ObservableCollection<ObservableUser> Users { get; } = new();

    public ObservableUser? SelectedUser {
      get => _SelectedUser;
      set => SetProperty(ref _SelectedUser, value);
    }

    #region CONSTRUCTORS
    public UsersViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      IMandatorsService.MandatorChanged += IMandatorsService_MandatorChanged;

      LoadUsers();
    }
    #endregion CONSTRUCTORS

    private void LoadUsers() {
      if (ServiceProvider.GetRequiredService<IUsersService>() is IUsersService service) {
        Users.Clear();

        foreach (UserRecord user in service.GetAll(ActiveMandator?.ToRecord())) {
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

    #region CALLBACKS
    private void IMandatorsService_MandatorChanged(object? sender, EventArgs e) {
      LoadUsers();
    }
    #endregion CALLBACKS
  }
}
