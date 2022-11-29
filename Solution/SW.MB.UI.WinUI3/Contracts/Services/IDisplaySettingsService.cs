using System.Threading.Tasks;
using SW.MB.UI.WinUI3.Models.Enumerations;

namespace SW.MB.UI.WinUI3.Contracts.Services {
  public interface IDisplaySettingsService {
    public PersonsDisplayMode PersonsDisplayMode { get; }
    public PersonsOrderingMode PersonsOrderingMode { get; }

    public Task InitializeAsync();
    public Task SetSettingAsync(PersonsDisplayMode displayMode);
    public Task SetSettingAsync(PersonsOrderingMode orderingMode);
  }
}
