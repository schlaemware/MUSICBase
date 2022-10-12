using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface IMusiciansService {
        public IEnumerable<MusicianRecord> GetAll();
    }
}
