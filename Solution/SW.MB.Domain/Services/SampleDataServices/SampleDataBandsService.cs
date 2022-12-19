using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.SampleDataServices.Abstracts;

namespace SW.MB.Domain.Services.SampleDataServices {
  internal class SampleDataBandsService: SampleDataServiceBase<BandRecord>, IBandsDataService {
    public void Update(BandRecord record) {
      throw new NotImplementedException();
    }

    protected override void CreateSampleData() {
      throw new NotImplementedException();
    }
  }
}
