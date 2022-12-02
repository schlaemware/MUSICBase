using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.SampleDataServices.Abstracts;

namespace SW.MB.Domain.Services.SampleDataServices {
  internal class SampleDataMembersService: SampleDataServiceBase<MemberRecord>, IMembersDataService {
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

    #region CONSTRUCTORS
    public SampleDataMembersService() : base() { }
    #endregion CONSTRUCTORS

    protected override void CreateSampleData() {
      Random random = new();
      int numOfMusicians = random.Next(10, 100);
      
      for (int n = 1; n <= numOfMusicians; n++) {
        _RecordsDictionary.Add(n, new MemberRecord() {
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
