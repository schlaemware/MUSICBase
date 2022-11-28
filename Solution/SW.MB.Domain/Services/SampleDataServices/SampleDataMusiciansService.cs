using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Services.SampleDataServices {
    internal class SampleDataMusiciansService : IMusiciansService {
        public IEnumerable<MusicianRecord> GetAll() {
            Random random = new Random();
            List<MusicianRecord> musicians = new();
            int numOfMusicians = random.Next(10, 100);
            for (int n = 0; n < numOfMusicians; n++) {
                musicians.Add(new MusicianRecord() {
                    Firstname = random.NextFirstname(),
                    Lastname = random.NextLastname(),
                    DateOfBirth = random.NextDateTimePast()
                });
            }

            return musicians;
        }

        public void UpdateRange(params MusicianRecord[] records) {
            throw new NotImplementedException();
        }
    }
}
