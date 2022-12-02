using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.SampleDataServices.Abstracts;

namespace SW.MB.Domain.Services.SampleDataServices {
  internal class SampleDataMusiciansService: SampleDataServiceBase<MusicianRecord>, IMusiciansDataService {
    #region CONSTRUCTORS
    public SampleDataMusiciansService() : base() { }
    #endregion CONSTRUCTORS

    protected override void CreateSampleData() {
      Random random = new();
      int numOfMusicians = random.Next(10, 100);

      for (int n = 1; n <= numOfMusicians; n++) {
        _RecordsDictionary.Add(n, new MusicianRecord() {
          ID = n,
          Created = random.NextDateTimePast(),
          CreatedBy = random.Next(),
          Updated = random.NextDateTimePast(),
          UpdatedBy = random.Next(),
          Firstname = random.NextFirstname(),
          Lastname = random.NextLastname(),
          DateOfBirth = random.NextDateTimePast()
        });
      }
    }
  }
}
