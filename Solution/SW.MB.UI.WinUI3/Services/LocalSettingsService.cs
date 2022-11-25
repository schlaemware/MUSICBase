using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Helpers;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Helpers;
using SW.MB.UI.WinUI3.Models;
using Windows.Storage;

namespace SW.MB.UI.WinUI3.Services {
  internal class LocalSettingsService: ILocalSettingsService {
    private const string _DefaultApplicationDataFolder = "Schlæmware\\MUSICBase";
    private const string _DefaultLocalSettingsFile = "LocalSettings.json";

    private readonly IFileService _FileService;
    private readonly LocalSettingsOptions _Options;
    private readonly string _LocalApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    private readonly string _ApplicationDataFolder;
    private readonly string _LocalSettingsFile;

    private IDictionary<string, object> _Settings = new Dictionary<string, object>();
    private bool _IsInitialized;

    #region CONSTRUCTORS
    public LocalSettingsService(IFileService fileService, IOptions<LocalSettingsOptions> options) {
      _FileService = fileService;
      _Options = options.Value;

      _ApplicationDataFolder = Path.Combine(_LocalApplicationData, _Options.ApplicationDataFolder ?? _DefaultApplicationDataFolder);
      _LocalSettingsFile = _Options.LocalSettingsFile ?? _DefaultLocalSettingsFile;
    }
    #endregion CONSTRUCTORS

    public async Task<T?> ReadSettingAsync<T>(string key) {
      if (RuntimeHelper.IsMSIX) {
        if (ApplicationData.Current.LocalSettings.Values.TryGetValue(key, out var obj)) {
          return await MyJsonConverter.ToObjectAsync<T>((string)obj);
        }
      } else {
        await InitializeAsync();

        if (_Settings != null && _Settings.TryGetValue(key, out var obj)) {
          return await MyJsonConverter.ToObjectAsync<T>((string)obj);
        }
      }

      return default;
    }

    public async Task SaveSettingAsync<T>(string key, T value) {
      if (RuntimeHelper.IsMSIX) {
        ApplicationData.Current.LocalSettings.Values[key] = await MyJsonConverter.StringifyAsync(value);
      } else {
        await InitializeAsync();
        _Settings[key] = await MyJsonConverter.StringifyAsync(value);
        await Task.Run(() => _FileService.Save(_ApplicationDataFolder, _LocalSettingsFile, _Settings));
      }
    }

    private async Task InitializeAsync() {
      if (!_IsInitialized) {
        _Settings = await Task.Run(() => _FileService.Read<IDictionary<string, object>>(_ApplicationDataFolder, _LocalSettingsFile)) ?? new Dictionary<string, object>();
        _IsInitialized = true;
      }
    }
  }
}
