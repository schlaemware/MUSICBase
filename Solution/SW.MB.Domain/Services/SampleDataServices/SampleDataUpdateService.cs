using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Services.SampleDataServices {
    internal class SampleDataUpdateService : IUpdatesService {
        public async Task<IEnumerable<ReleaseRecord>> CheckUpdatesAsync(string organization, string product, Version? installedVersion, params string[] extensions) {
            await Task.Delay(3000);

            Random random = new();
            List<ReleaseRecord> records = new();

            for (int n = 0; n < 10; n++) {
                records.Add(new ReleaseRecord() {
                    Designation = $"Release 0.0.0.{n}",
                    Version = new Version(0, 0, 0, n),
                    Description = "Hier könnte die Beschreibugn des Releases stehen...",
                    PreRelease = random.NextBoolean(),
                    Draft = random.NextBoolean(),
                    Created = DateTime.Now,
                    Published = DateTime.Now,
                    DownloadUri = random.NextBoolean() ? new Uri("https://www.schlaemware.ch") : default
                });
            }

            return records;
        }
    }
}
