using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using SW.MB.UI.WinUI3.Contracts.Services;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class SettingsViewModel: ObservableRecipient {
    private readonly IThemeSelectorService _ThemeSelectorService;

    private ElementTheme _Theme;

    public ElementTheme Theme {
      get => _Theme;
      set => SetProperty(ref _Theme, value);
    }

    public string VersionDescription { get; }

    public ICommand SwitchThemeCommand { get; }

    public SettingsViewModel(IThemeSelectorService themeSelectorService) {
      _ThemeSelectorService = themeSelectorService;
      VersionDescription = GetVersionDescription();

      SwitchThemeCommand = new RelayCommand<ElementTheme>(async param => {
        if (Theme != param) {
          Theme = param;
          await _ThemeSelectorService.SetThemeAsync(Theme);
        }
      });
    }

    private string GetVersionDescription() {
      return "Die Versionsbeschreibung wird noch nicht geladen.";
    }
  }
}
