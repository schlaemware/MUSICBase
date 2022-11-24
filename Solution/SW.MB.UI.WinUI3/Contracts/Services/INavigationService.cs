using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace SW.MB.UI.WinUI3.Contracts.Services {
  public interface INavigationService {
    public bool CanGoBack { get; }
    public Frame? Frame { get; set; }

    public event NavigatedEventHandler? Navigated;

    public bool GoBack();
    public bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false);
    // public void SetListDataItemForNextConnectedAnimation(object item);
  }
}
