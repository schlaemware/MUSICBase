using System;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
    public class AppViewModel : ViewModelBase {
        public ViewModelBase? CompositionsViewModel { get; }
        public ViewModelBase? MandatorsViewModel { get; }
        public ViewModelBase? MembersViewModel { get; }
        public ViewModelBase? MusiciansViewModel { get; }
        public ViewModelBase? SettingsViewModel { get; }
        public ViewModelBase? UpdatesViewModel { get; }
        public ViewModelBase? UsersViewModel { get; }

        public ObservableCollection<ObservableMandator> MandatorsCollection { get; } = new();

        #region CONSTRUCTORS
        public AppViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
            CompositionsViewModel = serviceProvider.GetService<CompositionsViewModel>();
            MandatorsViewModel = serviceProvider.GetService<MandatorsViewModel>();
            MembersViewModel = serviceProvider.GetService<MembersViewModel>();
            MusiciansViewModel = serviceProvider.GetService<MusiciansViewModel>();
            SettingsViewModel = serviceProvider.GetService<SettingsViewModel>();
            UpdatesViewModel = serviceProvider.GetService<UpdatesViewModel>();
            UsersViewModel = serviceProvider.GetService<UsersViewModel>();

            serviceProvider.GetRequiredService<IMandatorsService>().GetAllRaw().ForEach(x => MandatorsCollection.Add(new ObservableMandator(x)));
        }
        #endregion CONSTRUCTORS
    }
}
