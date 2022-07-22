using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using Local.Framework.WPF.ViewModels;
using SW.MB.UI.WPF.Core.Contracts.Commands;
using SW.MB.UI.WPF.Desktop.Contracts.Stores;

namespace SW.MB.UI.WPF.Desktop.ViewModels {
  public class AppViewModel: ExtendedViewModelBase {
    private readonly IModulesNavigationStore _NavigationStore;

    private bool _IsNavigationPanelReduced = Properties.Settings.Default.IsNavigationPanelReduced;

    public ICollectionView ModulesCollectionViewSource { get; }

    public bool IsNavigationPanelReduced {
      get => _IsNavigationPanelReduced;
      set {
        if (SetProperty(ref _IsNavigationPanelReduced, value)) {
          Properties.Settings.Default.IsNavigationPanelReduced = value;
        }
      }
    }

    #region COMMANDS
    public ICommand NavigateCompositionsCommand { get; }
    public ICommand NavigateDashboardCommand { get; }
    public ICommand NavigateMembersCommand { get; }
    public ICommand NavigateMusiciansCommand { get; }
    public ICommand NavigateSettingsCommand { get; }
    public ICommand NavigateUpdatesCommand { get; }
    #endregion COMMANDS

    #region CONSTRUCTORS
    public AppViewModel(IModulesNavigationStore navigationStore,
      INavigateCompositionsCommand navigateCompositionsCommand,
      INavigateDashboardCommand navigateDashboardCommand,
      INavigateMembersCommand navigateMembersCommand,
      INavigateMusiciansCommand navigateMusiciansCommand,
      INavigateSettingsCommand navigateSettingsCommand,
      INavigateUpdatesCommand navigateUpdatesCommand) {

      _NavigationStore = navigationStore;

      ModulesCollectionViewSource = CollectionViewSource.GetDefaultView(_NavigationStore.ViewModelCollection);

      NavigateCompositionsCommand = navigateCompositionsCommand;
      NavigateDashboardCommand = navigateDashboardCommand;
      NavigateMembersCommand = navigateMembersCommand;
      NavigateMusiciansCommand = navigateMusiciansCommand;
      NavigateSettingsCommand = navigateSettingsCommand;
      NavigateUpdatesCommand = navigateUpdatesCommand;

      NavigateDashboardCommand.Execute(null);
    }
    #endregion CONSTRUCTORS
  }
}
