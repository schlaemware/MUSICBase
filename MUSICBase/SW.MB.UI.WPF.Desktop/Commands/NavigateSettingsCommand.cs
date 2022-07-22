using System;
using Local.Framework.WPF.Commands;
using Local.Framework.WPF.Contracts.Stores;
using SW.MB.UI.WPF.Core.Contracts.Commands;
using SW.MB.UI.WPF.Desktop.ViewModels;

namespace SW.MB.UI.WPF.Desktop.Commands {
  internal class NavigateSettingsCommand: NavigateCommand<SettingsViewModel>, INavigateSettingsCommand {
    public NavigateSettingsCommand(INavigationStore navigationStore, Func<SettingsViewModel> factory)
      : base(navigationStore, factory) {
    }
  }
}
