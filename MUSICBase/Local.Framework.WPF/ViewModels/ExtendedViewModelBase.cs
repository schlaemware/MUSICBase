using SW.Framework.WPF.ViewModels;

namespace Local.Framework.WPF.ViewModels {
  public abstract class ExtendedViewModelBase : ViewModelBase {
    private bool _IsActive;

    public bool IsActive {
      get => _IsActive;
      set => SetProperty(ref _IsActive, value);
    }
  }
}
