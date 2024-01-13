using Microsoft.Extensions.DependencyInjection;
using SW.MB.UI.WPF.Interfaces;
using SW.MB.UI.WPF.Models;

namespace SW.MB.UI.WPF.ViewModels
{
    public class DashboardViewModel : BaseViewModel, INavigableObject
    {
        public INavigateCommand NavigateToCompositionsCommand { get; } 
            = App.ServiceProvider.GetRequiredService<INavigateCommand<CompositionsViewModel>>();
    }
}
