using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Services.SampleDataServices {
    internal class SampleDataMembersService : IMembersService {
        private static readonly string[] _INSTRUMENTS = new string[] {
            "Piccolo",
            "Flöte",
            "Klarinette",
            "Saxophon",
            "Trompete",
            "Posaune",
            "Euphonium",
            "Tuba",
            "Schlagwerk"
        };

        public IEnumerable<MemberRecord> GetAll(params MandatorRecord?[]? mandators) {
            Random random = new();
            int numOfMusicians = random.Next(10, 100);
            List<MemberRecord> members = new();
            for (int n = 0; n < numOfMusicians; n++) {
                members.Add(new MemberRecord() {
                    Firstname = random.NextFirstname(),
                    Lastname = random.NextLastname(),
                    DateOfBirth = random.NextDateTimePast(),
                    Instrument = _INSTRUMENTS[random.Next(_INSTRUMENTS.Length)]
                });
            }

            return members;
        }

        public void UpdateRange(params MemberRecord[] records) {
            throw new NotImplementedException();
        }
    }
}
