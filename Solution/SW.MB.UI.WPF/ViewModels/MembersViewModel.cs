using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
    public class MembersViewModel : ViewModelBase {
        public ObservableCollection<ObservableMember> Members { get; } = new();

        #region CONSTRUCTORS
        public MembersViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
            IMandatorsService.MandatorChanged += IMandatorsService_MandatorChanged;
            
            LoadMembers();
        }
        #endregion CONSTRUCTORS

        private void LoadMembers() {
            if (ServiceProvider.GetService<IMembersService>() is IMembersService service) {
                Members.Clear();

                foreach (MemberRecord member in service.GetAll(ActiveMandator?.ToRecord())) {
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

        #region CALLBACKS
        private void IMandatorsService_MandatorChanged(object? sender, EventArgs e) {
            LoadMembers();
        }
        #endregion CALLBACKS
    }
}
