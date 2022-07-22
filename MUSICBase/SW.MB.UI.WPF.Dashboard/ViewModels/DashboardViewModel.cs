using System.Windows.Controls;
using Local.Framework.WPF.Contracts.ViewModels;
using Local.Framework.WPF.ViewModels;
using SW.MB.UI.WPF.Dashboard.Views.Controls;

namespace SW.MB.UI.WPF.Dashboard.ViewModels {
  public class DashboardViewModel: ExtendedViewModelBase, IModuleViewModel {
    public UserControl Content { get; } = new DashboardControl();
  }
}
