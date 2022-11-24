using System;
using System.Threading.Tasks;
using SW.MB.UI.WinUI3.Contracts.Services;

namespace SW.MB.UI.WinUI3.Services {
  internal class LocalSettingsService: ILocalSettingsService {
    public Task<T?> ReadSettingAsync<T>(string key) {
      throw new NotImplementedException();
    }

    public Task SaveSettingAsync<T>(string key, T value) {
      throw new NotImplementedException();
    }
  }
}
