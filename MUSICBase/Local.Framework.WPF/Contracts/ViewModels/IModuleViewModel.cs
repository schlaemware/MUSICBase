using System.Windows.Controls;

namespace Local.Framework.WPF.Contracts.ViewModels {
  public interface IModuleViewModel {
    public UserControl Content { get; }
    public bool IsActive { get; }
  }
}
