using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.SampleDataServices.Abstracts;

namespace SW.MB.Domain.Services.SampleDataServices {
  internal class SampleCompositionsDataService: SampleDataServiceBase<CompositionRecord>, ICompositionsDataService {
    public void Update(CompositionRecord record) {
      throw new NotImplementedException();
    }

    protected override void CreateSampleData() {
      Random random = new();
      int numOfCompositions = random.Next(100, 1000);

      for (int n = 1; n <= numOfCompositions; n++) {
        _RecordsDictionary.Add(n, new CompositionRecord() {
          ID = n,
          Created = random.NextDateTimePast(),
          CreatedBy = random.Next(),
          Updated = random.NextDateTimePast(),
          UpdatedBy = random.Next(),
          Title = random.NextTitle()
        });
      }
    }
  }
}
