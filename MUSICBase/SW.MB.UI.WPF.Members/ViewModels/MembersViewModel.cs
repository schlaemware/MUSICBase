using System.Windows.Controls;
using Local.Framework.WPF.Contracts.ViewModels;
using Local.Framework.WPF.ViewModels;
using SW.MB.UI.WPF.Members.Views.Controls;

namespace SW.MB.UI.WPF.Members.ViewModels {
  internal class MembersViewModel: ExtendedViewModelBase, IModuleViewModel {
    public UserControl Content { get; } = new MembersControl();
  }
}
