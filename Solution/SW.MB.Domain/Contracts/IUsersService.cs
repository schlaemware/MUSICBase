using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts {
  public interface IUsersService {
    public IEnumerable<UserRecord> GetAll();
  }
}
