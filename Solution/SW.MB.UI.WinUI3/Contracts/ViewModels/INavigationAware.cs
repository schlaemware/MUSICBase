namespace SW.MB.UI.WinUI3.Contracts.ViewModels {
  public interface INavigationAware {
    public void OnNavigatedTo(object parameter);

    public void OnNavigatedFrom();
  }
}
