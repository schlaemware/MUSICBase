using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Views.Pages;

namespace SW.MB.UI.WinUI3.ViewModels {
    public class ShellViewModel : ObservableRecipient {
        private bool _IsBackEnabled;
        private object? _Selected;

        public INavigationService NavigationService { get; }

        public INavigationViewService NavigationViewService { get; }

        public bool IsBackEnabled {
            get => _IsBackEnabled;
            set => SetProperty(ref _IsBackEnabled, value);
        }

        public object? Selected {
            get => _Selected;
            set => SetProperty(ref _Selected, value);
        }

        #region CONSTRUCTORS
        public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService) {
            NavigationService = navigationService;
            NavigationService.Navigated += NavigationService_Navigated;
            NavigationViewService = navigationViewService;
        }
        #endregion CONSTRUCTORS

        #region CALLBACKS
        private void NavigationService_Navigated(object sender, NavigationEventArgs e) {
            IsBackEnabled = NavigationService.CanGoBack;

            if (e.SourcePageType == typeof(SettingsPage)) {
                Selected = NavigationViewService.SettingsItem;
                return;
            }

            NavigationViewItem? selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
            if (selectedItem != null) {
                Selected = selectedItem;
            }
        }
        #endregion CALLBACKS
    }
}
