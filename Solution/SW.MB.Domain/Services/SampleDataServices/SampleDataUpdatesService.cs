using System.Collections.Generic;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Services.SampleDataServices {
  internal class SampleDataUpdatesService: IUpdatesService {
    public Task<IEnumerable<ReleaseRecord>> CheckUpdatesAsync(string organization, string product, Version? installedVersion, params string[] extensions) {
      List<ReleaseRecord> records = new();
      Random random = new();
      int numOfMajors = random.Next(3);
      for (int major = 0; major <= numOfMajors; major++) {
        int numOfMinors = random.Next(3);
        for (int minor = 0; minor <= numOfMinors; minor++) {
          int numOfReleases = random.Next(3);
          for (int release = 0; release <= numOfReleases; release++) {
            int numOfBuilds = random.Next(3);
            for (int build = 0; build <= numOfBuilds; build++) {
              records.Add(new ReleaseRecord() {
                Designation = $"Release {major}.{minor}.{release}.{build}",
                Version = new Version(major, minor, release, build),
                Description = "Hier könnte die Beschreibung des Releases stehen...",
                PreRelease = random.NextBoolean(),
                Draft = random.NextBoolean(),
                Created = DateTime.Now,
                Published = DateTime.Now,
                DownloadUri = random.NextBoolean() ? new Uri("https://www.schlaemware.ch") : default
              });
            }
          }
        }
      }

      return Task<IEnumerable<ReleaseRecord>>.Factory.StartNew(() => {
        List<ReleaseRecord> timedRecords = new();
        DateTime published;
        DateTime created = DateTime.Now;
        foreach (var item in records.OrderByDescending(x => x.Version)) {
          published = random.NextDateTime(created.AddDays(-7), created);
          created = random.NextDateTime(published.AddDays(-7), published);
          timedRecords.Add(item with { Created = created, Published = published });
        }

        return timedRecords;
      });
    }
  }
}
