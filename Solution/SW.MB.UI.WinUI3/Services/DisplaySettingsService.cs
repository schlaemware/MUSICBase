using System.Threading.Tasks;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Models.Enumerations;

namespace SW.MB.UI.WinUI3.Services {
  internal class DisplaySettingsService: IDisplaySettingsService {
    private readonly ILocalSettingsService _LocalSettingsService;

    public PersonsDisplayMode PersonsDisplayMode { get; private set; }
    public PersonsOrderingMode PersonsOrderingMode { get; private set; }

    #region CONSTRUCTORS
    public DisplaySettingsService(ILocalSettingsService localSettingsService) {
      _LocalSettingsService = localSettingsService;
    }
    #endregion CONSTRUCTORS

    public async Task InitializeAsync() {
      PersonsDisplayMode = await _LocalSettingsService.ReadSettingAsync<PersonsDisplayMode>();
      PersonsOrderingMode = await _LocalSettingsService.ReadSettingAsync<PersonsOrderingMode>();

      await Task.CompletedTask;
    }

    public async Task SetSettingAsync(PersonsDisplayMode displayMode) {
      PersonsDisplayMode = displayMode;
      await _LocalSettingsService.SaveSettingAsync(displayMode);
    }

    public async Task SetSettingAsync(PersonsOrderingMode orderingMode) {
      PersonsOrderingMode = orderingMode;
      await _LocalSettingsService.SaveSettingAsync(orderingMode);
    }
  }
}
