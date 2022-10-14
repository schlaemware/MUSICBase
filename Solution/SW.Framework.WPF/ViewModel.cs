using System;

namespace SW.Framework.WPF {
  public abstract class ViewModel: ObservableObject {
    private static IServiceProvider? _ServiceProvider;

    public static bool IsDebug {
#if DEBUG
      get => true;
#else
      get => false;
#endif
    }

    protected IServiceProvider ServiceProvider => _ServiceProvider
      ?? throw new ApplicationException($"{nameof(_ServiceProvider)} not instantiated!");

    #region CONSTRUCTORS
    public ViewModel(IServiceProvider serviceProvider) {
      _ServiceProvider ??= serviceProvider;
    }
    #endregion CONSTRUCTORS
  }
}
