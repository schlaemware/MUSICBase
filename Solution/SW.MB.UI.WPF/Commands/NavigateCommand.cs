using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.UI.WPF.Interfaces;
using SW.MB.UI.WPF.Models;

[assembly: InternalsVisibleTo("SW.MB.UI.WPF.Host")]

namespace SW.MB.UI.WPF.Commands {
    internal class NavigateCommand<T> : INavigateCommand<T> where T : INavigableObject
    {
        private readonly INavigationStore _NavigationStore;

        public event EventHandler? CanExecuteChanged;

        #region CONSTRUCTORS
        public NavigateCommand(INavigationStore navigationStore) 
            => _NavigationStore = navigationStore;
        #endregion CONSTRUCTORS

        public bool CanExecute() => CanExecute(null);

        public bool CanExecute(object? parameter = null)
            => App.ServiceProvider.GetService<T>() != null;

        public void Execute() => Execute(null);

        public void Execute(object? parameter = null) 
            => _NavigationStore.NavigateTo<T>();
    }
}
