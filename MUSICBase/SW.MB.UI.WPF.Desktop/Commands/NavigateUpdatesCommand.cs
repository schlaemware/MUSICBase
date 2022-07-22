using System;
using Local.Framework.WPF.Commands;
using Local.Framework.WPF.Contracts.Stores;
using SW.MB.UI.WPF.Core.Contracts.Commands;
using SW.MB.UI.WPF.Desktop.ViewModels;

namespace SW.MB.UI.WPF.Desktop.Commands {
  internal class NavigateUpdatesCommand: NavigateCommand<UpdatesViewModel>, INavigateUpdatesCommand {
    public NavigateUpdatesCommand(INavigationStore navigationStore, Func<UpdatesViewModel> factory)
      : base(navigationStore, factory) {
    }
  }
}
