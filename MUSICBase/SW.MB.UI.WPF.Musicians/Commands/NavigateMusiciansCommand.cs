using System;
using Local.Framework.WPF.Commands;
using Local.Framework.WPF.Contracts.Stores;
using SW.MB.UI.WPF.Core.Contracts.Commands;
using SW.MB.UI.WPF.Musicians.ViewModels;

namespace SW.MB.UI.WPF.Musicians.Commands {
  internal class NavigateMusiciansCommand: NavigateCommand<MusiciansViewModel>, INavigateMusiciansCommand {
    public NavigateMusiciansCommand(INavigationStore navigationStore, Func<MusiciansViewModel> factory)
      : base(navigationStore, factory) {
    }
  }
}
