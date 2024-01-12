using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.UI.WPF.Interfaces;

namespace SW.MB.UI.WPF.Stores
{
    internal class NavigationStore : ObservableObject, INavigationStore
    {
        private INavigableObject? _CurrentViewModel;

        public INavigableObject? CurrentViewModel {
            get => _CurrentViewModel;
            private set => SetProperty(ref _CurrentViewModel, value);
        }

        #region CONSTRUCTORS
        public NavigationStore() : base()
        {

        }
        #endregion CONSTRUCTORS

        public bool CanNavigateTo<T>() where T : INavigableObject 
            => App.Current.ServiceProvider.GetService<T>() != null;

        public void NavigateTo<T>() where T : INavigableObject 
            => CurrentViewModel = App.Current.ServiceProvider.GetService<T>();
    }
}
