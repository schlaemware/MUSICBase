using System.Reflection;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Models.Enumerations;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class SettingsViewModel: ObservableRecipient {
    private readonly IDisplaySettingsService _DisplaySettingsService;
    private readonly IThemeSelectorService _ThemeSelectorService;

    private PersonsDisplayMode _PersonsDisplayMode;
    private PersonsOrderingMode _PersonsOrderingMode;
    private ElementTheme _Theme;

    public PersonsDisplayMode PersonsDisplayMode {
      get => _PersonsDisplayMode;
      set => SetProperty(ref _PersonsDisplayMode, value);
    }

    public PersonsOrderingMode PersonsOrderingMode {
      get => _PersonsOrderingMode;
      set => SetProperty(ref _PersonsOrderingMode, value);
    }

    public ElementTheme Theme {
      get => _Theme;
      set => SetProperty(ref _Theme, value);
    }

    public string VersionString { get; } = $"Version {Assembly.GetExecutingAssembly().GetName().Version}";
    public string VersionDescription { get; }

    #region COMMANDS
    public ICommand SwitchPersonsDisplayCommand { get; }
    public ICommand SwitchPersonsOrderingCommand { get; }
    public ICommand SwitchThemeCommand { get; }
    #endregion COMMANDS

    #region CONSTRUCTORS
    public SettingsViewModel(IDisplaySettingsService displaySettingsService, IThemeSelectorService themeSelectorService) {
      _DisplaySettingsService = displaySettingsService;
      _PersonsDisplayMode = _DisplaySettingsService.PersonsDisplayMode;
      _PersonsOrderingMode = _DisplaySettingsService.PersonsOrderingMode;

      _ThemeSelectorService = themeSelectorService;
      _Theme = _ThemeSelectorService.Theme;

      VersionDescription = GetVersionDescription();

      // Commands
      SwitchPersonsDisplayCommand = new RelayCommand<PersonsDisplayMode>(async param => {
        if (PersonsDisplayMode != param) {
          PersonsDisplayMode = param;
          await _DisplaySettingsService.SetSettingAsync(PersonsDisplayMode);
        }
      });

      SwitchPersonsOrderingCommand = new RelayCommand<PersonsOrderingMode>(async param => {
        if (PersonsOrderingMode != param) {
          PersonsOrderingMode = param;
          await _DisplaySettingsService.SetSettingAsync(PersonsOrderingMode);
        }
      });

      SwitchThemeCommand = new RelayCommand<ElementTheme>(async param => {
        if (Theme != param) {
          Theme = param;
          await _ThemeSelectorService.SetThemeAsync(Theme);
        }
      });
    }
    #endregion CONSTRUCTORS

    private string GetVersionDescription() {
      return "Die Versionsbeschreibung wird noch nicht geladen.";
    }
  }
}
