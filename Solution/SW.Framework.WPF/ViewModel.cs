using System;

namespace SW.Framework.WPF {
    public abstract class ViewModel : ObservableObject {
        private static IServiceProvider? _ServiceProvider;

        protected IServiceProvider ServiceProvider => _ServiceProvider
          ?? throw new ApplicationException($"{nameof(_ServiceProvider)} not instantiated!");

        #region CONSTRUCTORS
        public ViewModel(IServiceProvider serviceProvider) {
            _ServiceProvider ??= serviceProvider;
        }
        #endregion CONSTRUCTORS
    }
}
