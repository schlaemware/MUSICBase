using System;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using SW.MB.UI.WinUI3.Contracts.Services;

namespace SW.MB.UI.WinUI3.Services {
  internal class ThemeSelectorService: IThemeSelectorService {
    private const string SettingsKey = "AppBackgroundRequestedTheme";

    private readonly ILocalSettingsService _LocalSettingsService;

    public ElementTheme Theme { get; set; } = ElementTheme.Default;

    #region CONSTRUCTORS
    public ThemeSelectorService(ILocalSettingsService localSettingsService) {
      _LocalSettingsService = localSettingsService;
    }
    #endregion CONSTRUCTORS

    public async Task InitializeAsync() {
      Theme = ElementTheme.Default; // await LoadThemeFromSettingsAsync();
      await Task.CompletedTask;
    }

    public async Task SetRequestedThemeAsync() {
      if (App.MainWindow.Content is FrameworkElement rootElement) {
        rootElement.RequestedTheme = Theme;
        // TitleBarHelper
      }

      await Task.CompletedTask;
    }

    public async Task SetThemeAsync(ElementTheme theme) {
      Theme = theme;

      await SetRequestedThemeAsync();
      await SaveThemeInSettingsAsync(Theme);
    }

    private async Task<ElementTheme> LoadThemeFromSettingsAsync() {
      string? themeName = await _LocalSettingsService.ReadSettingAsync<string>(SettingsKey);

      if (Enum.TryParse(themeName, out ElementTheme cacheTheme)) {
        return cacheTheme;
      }

      return ElementTheme.Default;
    }

    private async Task SaveThemeInSettingsAsync(ElementTheme theme) {
      await _LocalSettingsService.SaveSettingAsync(SettingsKey, theme.ToString());
    }
  }
}
