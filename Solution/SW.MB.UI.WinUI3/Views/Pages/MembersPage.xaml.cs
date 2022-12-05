using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SW.MB.UI.WinUI3.ViewModels;

namespace SW.MB.UI.WinUI3.Views.Pages {
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MembersPage: Page {
    public MembersViewModel ViewModel { get; }

    public MembersPage() {
      ViewModel = App.GetService<MembersViewModel>();

      InitializeComponent();
    }

    private void ListView_Loaded(object sender, RoutedEventArgs e) {
      if (sender is ListView listView && ViewModel.SelectedMember != null) {
        listView.ScrollIntoView(ViewModel.SelectedMember);
      }
    }
  }
}
