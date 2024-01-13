using Microsoft.Extensions.DependencyInjection;
using SW.MB.UI.WPF.Interfaces;
using SW.MB.UI.WPF.Models;

namespace SW.MB.UI.WPF.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        private readonly INavigationStore _NavigationStore;

        public INavigableObject? CurrentViewModel => _NavigationStore.CurrentViewModel;

        public INavigateCommand NavigateToCompositionsCommand { get; } 
            = App.ServiceProvider.GetRequiredService<INavigateCommand<CompositionsViewModel>>();

        public INavigateCommand NavigateToDashboardCommand { get; }
            = App.ServiceProvider.GetRequiredService<INavigateCommand<DashboardViewModel>>();

        public INavigateCommand NavigateToMusiciansCommand { get; }
            = App.ServiceProvider.GetRequiredService<INavigateCommand<MusiciansViewModel>>();

        public AppViewModel(INavigationStore navigationStore) : base()
        {
            _NavigationStore = navigationStore;
            _NavigationStore.PropertyChanged += NavigationStore_PropertyChanged;

            if (NavigateToDashboardCommand.CanExecute()) {
                NavigateToDashboardCommand.Execute();
            }
        }

        private void NavigationStore_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName) {
                case nameof(CurrentViewModel):
                    OnPropertyChanged(nameof(CurrentViewModel));
                    break;
            }
        }
    }
}
