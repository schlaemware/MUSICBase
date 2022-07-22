using System;
using Local.Framework.WPF.Commands;
using Local.Framework.WPF.Contracts.Stores;
using SW.MB.UI.WPF.Core.Contracts.Commands;
using SW.MB.UI.WPF.Dashboard.ViewModels;

namespace SW.MB.UI.WPF.Dashboard.Commands {
  internal class NavigateDashboardCommand: NavigateCommand<DashboardViewModel>, INavigateDashboardCommand {
    public NavigateDashboardCommand(INavigationStore navigationStore, Func<DashboardViewModel> factory) : base(navigationStore, factory) {

    }
  }
}
