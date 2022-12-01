using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Services.SampleDataServices {
  internal class SampleDataMembersService: IMembersService {
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

    private static readonly Dictionary<int, MemberRecord> _MemberRecordsDictionary = new();

    public SampleDataMembersService() {
      if (!_MemberRecordsDictionary.Any()) {
        CreateSampleData();
      }
    }

    public IEnumerable<MemberRecord> GetAll(params MandatorRecord?[]? mandators) {
      return _MemberRecordsDictionary.Values;
    }

    public void UpdateRange(params MemberRecord[] records) {
      foreach (MemberRecord record in records) {
        _MemberRecordsDictionary.Remove(record.ID);
        _MemberRecordsDictionary.Add(record.ID, record);
      }
    }

    private void CreateSampleData() {
      Random random = new();
      int numOfMusicians = random.Next(10, 100);
      
      for (int n = 1; n <= numOfMusicians; n++) {
        _MemberRecordsDictionary.Add(n, new MemberRecord() {
          ID = n,
          Created = random.NextDateTimePast(),
          CreatedBy = random.Next(),
          Updated = random.NextDateTimePast(),
          UpdatedBy = random.Next(),
          Firstname = random.NextFirstname(),
          Lastname = random.NextLastname(),
          DateOfBirth = random.NextDateTimePast(),
          Instrument = _INSTRUMENTS[random.Next(_INSTRUMENTS.Length)]
        });
      }
    }
  }
}
