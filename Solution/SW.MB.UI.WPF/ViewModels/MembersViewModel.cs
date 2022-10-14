using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SW.Framework.WPF;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
  public class MembersViewModel: ViewModel {
    public ObservableCollection<ObservableMember> Members { get; } = new();

    #region CONSTRUCTORS
    public MembersViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      LoadMembers();
    }
    #endregion CONSTRUCTORS

    private void LoadMembers() {
      if (ServiceProvider.GetService<IMembersService>() is IMembersService service) {
        foreach (MemberRecord member in service.GetAll()) {
          Members.Add(new ObservableMember(member));
        }
      }
    }

    private void StoreMembers() {
      if (ServiceProvider.GetService<IMembersService>() is IMembersService service) {
        service.UpdateRange(Members.Select(x => x.ToRecord()).ToArray());
        LoadMembers();
      }
    }
  }
}
