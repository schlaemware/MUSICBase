using System.Windows.Controls;
using Local.Framework.WPF.Contracts.ViewModels;
using Local.Framework.WPF.ViewModels;
using SW.MB.UI.WPF.Desktop.Views.Controls;

namespace SW.MB.UI.WPF.Desktop.ViewModels {
  public class UpdatesViewModel: ExtendedViewModelBase, IModuleViewModel {
    public UserControl Content { get; } = new UpdatesControl();
  }
}
