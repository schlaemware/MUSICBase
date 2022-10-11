using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts {
  public interface IMusiciansService {
    public IEnumerable<MusicianRecord> GetAll();
  }
}
