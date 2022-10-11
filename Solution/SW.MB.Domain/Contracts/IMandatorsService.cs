using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts {
  public interface IMandatorsService {
    public IEnumerable<MandatorRecord> GetAll();
  }
}
