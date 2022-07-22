using System;
using Local.Framework.WPF.Commands;
using Local.Framework.WPF.Contracts.Stores;
using SW.MB.UI.WPF.Core.Contracts.Commands;
using SW.MB.UI.WPF.Members.ViewModels;

namespace SW.MB.UI.WPF.Members.Commands {
  internal class NavigateMembersCommand: NavigateCommand<MembersViewModel>, INavigateMembersCommand {
    public NavigateMembersCommand(INavigationStore navigationStore, Func<MembersViewModel> factory)
      : base(navigationStore, factory) {
    }
  }
}
