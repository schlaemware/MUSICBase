using Microsoft.Extensions.DependencyInjection;
using SW.MB.UI.WPF.Interfaces;

namespace SW.MB.UI.WPF.ViewModels
{
    public class DashboardViewModel : BaseViewModel, INavigableObject
    {
        public INavigateCommand NavigateToCompositionsCommand { get; } 
            = App.Current.ServiceProvider.GetRequiredService<INavigateCommand<CompositionsViewModel>>();
    }
}
