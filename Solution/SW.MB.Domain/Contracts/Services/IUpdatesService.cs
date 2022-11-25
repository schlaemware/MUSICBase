using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
  public interface IUpdatesService {
    public Task<IEnumerable<ReleaseRecord>> CheckUpdatesAsync(string organization, string product, Version? installedVersion, params string[] extensions);
  }
}
