using System.Threading.Tasks;

namespace SW.MB.UI.WinUI3.Contracts.Services {
  public interface ILocalSettingsService {
    public Task<T?> ReadSettingAsync<T>(string key);
    public Task SaveSettingAsync<T>(string key, T value);
  }
}
