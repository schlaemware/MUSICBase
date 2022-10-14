using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface IMusiciansService {
        public IEnumerable<MusicianRecord> GetAll();
        public IEnumerable<MusicianRecord> GetAll(params MandatorRecord?[]? mandators);

        public void UpdateRange(params MusicianRecord[] records);
    }
}
