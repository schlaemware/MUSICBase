using System;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using SW.Framework.WPF;
using SW.MB.Domain.Contracts.Services;

namespace SW.MB.UI.WPF.ViewModels {
    public class SettingsViewModel : PageViewModel {
        #region COMMANDS
        public ICommand GenereateSampleDataCommand { get; }
        #endregion COMMANDS

        #region CONSTRUCTORS
        public SettingsViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
            GenereateSampleDataCommand = new RelayCommand(obj => ServiceProvider.GetService<IApplicationService>()?.GenerateSampleData(), obj => IsDebug);
        }
        #endregion CONSTRUCTORS
    }
}
