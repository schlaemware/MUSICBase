using System.Windows.Controls;
using Local.Framework.WPF.Contracts.ViewModels;
using Local.Framework.WPF.ViewModels;
using SW.MB.UI.WPF.Musicians.Views.Controls;

namespace SW.MB.UI.WPF.Musicians.ViewModels {
  internal class MusiciansViewModel: ExtendedViewModelBase, IModuleViewModel {
    public UserControl Content { get; } = new MusiciansControl();
  }
}
