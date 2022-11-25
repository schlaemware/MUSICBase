using Octokit;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
  internal class DefaultUpdatesService: DataServiceBase, IUpdatesService {
    public DateTime LastUpdatesCheck { get; private set; }

    public async Task<IEnumerable<ReleaseRecord>> CheckUpdatesAsync(string organization, string product, Version? installedVersion, params string[] extensions) {
      List<ReleaseRecord> releaseRecords = new();

      if (LastUpdatesCheck < DateTime.Today) {
        // Check updates only once per day
        LastUpdatesCheck = DateTime.Today;
        
        GitHubClient client = new(new ProductHeaderValue(organization));
        IReadOnlyList<Repository> repositories = await client.Repository.GetAllForOrg(organization);

        if (repositories.FirstOrDefault(x => x.Name.ToLower() == product.ToLower()) is Repository repository) {
          IEnumerable<Release> releases = await client.Repository.Release.GetAll(repository.Id);

          releases.ForEach(async release => {
            if (Version.TryParse(release.TagName, out Version? version)) {
              ReleaseRecord releaseRecord = ToRecord(release, version);

              if (installedVersion != null && version > installedVersion) {
                IReadOnlyList<ReleaseAsset> assets = await client.Repository.Release.GetAllAssets(repository.Id, release.Id);
                ReleaseAsset? installer = assets.FirstOrDefault(x => extensions.Any(y => x.Name.EndsWith(y)));
                if (installer != null) {
                  releaseRecord = releaseRecord with { DownloadUri = new Uri(installer.BrowserDownloadUrl) };
                }
              }

              releaseRecords.Add(releaseRecord);
            }
          });
        }
      }

      return releaseRecords;
    }

    private static ReleaseRecord ToRecord(Release release, Version? version = null) {
      return new ReleaseRecord() {
        Designation = release.Name,
        Version = version ?? Version.Parse(release.TagName),
        Description = release.Body,
        Draft = release.Draft,
        PreRelease = release.Prerelease,
        Created = release.CreatedAt,
        Published = release.PublishedAt
      };
    }
  }
}
