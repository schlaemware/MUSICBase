using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace SW.MB.UI.WinUI3.Contracts.Services {
  public interface IThemeSelectorService {
    public ElementTheme Theme { get; }

    public Task InitializeAsync();
    public Task SetRequestedThemeAsync();
    public Task SetThemeAsync(ElementTheme theme);
  }
}
