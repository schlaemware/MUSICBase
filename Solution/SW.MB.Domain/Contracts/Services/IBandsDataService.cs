using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface IBandsDataService {
        public IEnumerable<BandRecord> GetAll();

        public void Update(BandRecord record);

        public void UpdateRange(params BandRecord[] records);
    }
}
