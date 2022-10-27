using System;
using SW.Framework.WPF;

namespace SW.MB.UI.WPF.ViewModels {
    public abstract class ViewModelBase : ViewModel {
        #region CONSTRUCTORS
        public ViewModelBase(IServiceProvider serviceProvider) : base(serviceProvider) {

        }
        #endregion CONSTRUCTORS

        public virtual void Initialize() {
            // empty...
        }
    }
}
