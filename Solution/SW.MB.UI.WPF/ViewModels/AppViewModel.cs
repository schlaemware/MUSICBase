using System;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
    public class AppViewModel : ViewModelBase {
        public PageViewModel? CompositionsViewModel { get; }
        public PageViewModel? DashboardViewModel { get; }
        public MandatorsViewModel? MandatorsViewModel { get; }
        public PageViewModel? MembersViewModel { get; }
        public PageViewModel? MusiciansViewModel { get; }
        public PageViewModel? SettingsViewModel { get; }
        public PageViewModel? UpdatesViewModel { get; }
        public PageViewModel? UsersViewModel { get; }

        public ObservableCollection<ObservableMandator> MandatorsCollection { get; } = new();

        #region CONSTRUCTORS
        public AppViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
            CompositionsViewModel = serviceProvider.GetService<CompositionsViewModel>();
            DashboardViewModel = serviceProvider.GetService<DashboardViewModel>();
            MandatorsViewModel = serviceProvider.GetService<MandatorsViewModel>();
            MembersViewModel = serviceProvider.GetService<MembersViewModel>();
            MusiciansViewModel = serviceProvider.GetService<MusiciansViewModel>();
            SettingsViewModel = serviceProvider.GetService<SettingsViewModel>();
            UpdatesViewModel = serviceProvider.GetService<UpdatesViewModel>();
            UsersViewModel = serviceProvider.GetService<UsersViewModel>();

            serviceProvider.GetRequiredService<IMandatorsService>().GetAllRaw().ForEach(x => MandatorsCollection.Add(new ObservableMandator(x)));

            if (DashboardViewModel != null) {
                DashboardViewModel.IsActive = true;
            } else if (CompositionsViewModel != null) {
                CompositionsViewModel.IsActive = true;
            } else {
                throw new ApplicationException();
            }
        }
        #endregion CONSTRUCTORS

        public override void Initialize() {
            MandatorsViewModel?.Initialize();
            UsersViewModel?.Initialize();
            DashboardViewModel?.Initialize();
            CompositionsViewModel?.Initialize();
            MusiciansViewModel?.Initialize();
            MembersViewModel?.Initialize();
            SettingsViewModel?.Initialize();
            UpdatesViewModel?.Initialize();
        }
    }
}
