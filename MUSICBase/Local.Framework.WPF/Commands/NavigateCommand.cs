using System;
using Local.Framework.WPF.Contracts.Stores;
using Local.Framework.WPF.ViewModels;

namespace Local.Framework.WPF.Commands {
  public abstract class NavigateCommand : CommandBase {
    protected readonly INavigationStore _NavigationStore;

    public NavigateCommand(INavigationStore navigationStore) {
      _NavigationStore = navigationStore;
    }
  }

  public abstract class NavigateCommand<T> : NavigateCommand where T : ExtendedViewModelBase {
    private readonly Func<T> _Factory;

    public NavigateCommand(INavigationStore navigationStore, Func<T> factory) : base(navigationStore) {
      _Factory = factory;
    }

    public override void Execute(object? parameter) {
      _NavigationStore.NavigateTo(_Factory);
    }
  }

  public abstract class NavigateCommand<T, K> : NavigateCommand where T : ExtendedViewModelBase where K : struct {
    private readonly Func<K?, T> _Factory;

    public NavigateCommand(INavigationStore navigationStore, Func<K?, T> factory) : base(navigationStore) {
      _Factory = factory;
    }

    public override void Execute(object? parameter) {
      _NavigationStore.NavigateTo<T, K>(_Factory, parameter as K?);
    }
  }
}
