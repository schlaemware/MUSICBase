using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.SampleDataServices.Abstracts;

namespace SW.MB.Domain.Services.SampleDataServices {
  internal class SampleDataMandatorsService: SampleDataServiceBase<MandatorRecord>, IMandatorsDataService {
    protected override void CreateSampleData() {
      Random random = new();
      int numOfMandators = random.Next(1, 10);

      for (int n = 1; n <= numOfMandators; n++) {
        _RecordsDictionary.Add(n, new MandatorRecord() {
          ID = n,
          Created = random.NextDateTimePast(),
          CreatedBy = random.Next(),
          Updated = random.NextDateTimePast(),
          UpdatedBy = random.Next(),
          Name = n switch {
            1 => "Musikverein Berneck",
            2 => "Musikverein Balgach",
            3 => "Musikverein Heerbrugg",
            4 => "Jodelchörli Immerschwanger",
            5 => "Jugendblasorchester Bad Berneck",
            6 => "Wiener Philharmonika",
            7 => "Stadtmusik Basel",
            8 => "Stadtorchester Luzern",
            9 => "Banana-Musik",
            10 => "Rheintal Musikanten",
            _ => random.NextTitle()
          }
        });
      }
    }
  }
}
