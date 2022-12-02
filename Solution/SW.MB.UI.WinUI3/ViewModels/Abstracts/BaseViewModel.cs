using CommunityToolkit.Mvvm.ComponentModel;

namespace SW.MB.UI.WinUI3.ViewModels.Abstracts {
  public abstract class BaseViewModel : ObservableRecipient {
    #region CONSTRUCTORS
    public BaseViewModel() : base() {
      IsActive = true;
    }

    ~BaseViewModel() {
      IsActive = false;
    }
    #endregion CONSTRUCTORS
  }
}
