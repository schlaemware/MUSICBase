using System;
using Serilog;

namespace SW.MB.UI.WPF.ViewModels {
  public abstract class PageViewModel: ViewModelBase {
    private bool _IsActive;

    public bool IsActive {
      get => _IsActive;
      set {
        if (SetProperty(ref _IsActive, value)) {
          OnIsActiveChanged();
        }
      }
    }

    #region CONSTRUCTORS
    public PageViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {

    }
    #endregion CONSTRUCTORS

    protected virtual void OnIsActiveChanged() {
      if (IsActive) {
        Log.Logger.Debug($"{GetType().Name} activated...");
      } else {
        Log.Logger.Debug($"{GetType().Name} deactivated...");
      }
    }
  }
}
