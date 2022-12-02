using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface IMusiciansDataService {
        public IEnumerable<MusicianRecord> GetAll();

        public void UpdateRange(params MusicianRecord[] records);
    }
}
