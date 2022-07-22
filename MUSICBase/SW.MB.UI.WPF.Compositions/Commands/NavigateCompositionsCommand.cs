using System;
using Local.Framework.WPF.Commands;
using Local.Framework.WPF.Contracts.Stores;
using SW.MB.UI.WPF.Compositions.ViewModels;
using SW.MB.UI.WPF.Core.Contracts.Commands;

namespace SW.MB.UI.WPF.Compositions.Commands {
  internal class NavigateCompositionsCommand: NavigateCommand<CompositionsViewModel>, INavigateCompositionsCommand {
    public NavigateCompositionsCommand(INavigationStore navigationStore, Func<CompositionsViewModel> factory)
      : base(navigationStore, factory) {
    }
  }
}
