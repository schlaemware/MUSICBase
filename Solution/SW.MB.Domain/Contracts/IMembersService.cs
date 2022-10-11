using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts {
  public interface IMembersService {
    public IEnumerable<MemberRecord> GetAll();
  }
}
