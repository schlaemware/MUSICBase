using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
  public interface IUsersDataService {
    public IEnumerable<UserRecord> GetAll();
    public IEnumerable<UserRecord> GetAll(params MandatorRecord?[]? mandators);

    public bool TryLogIn(string name, string password, bool storeLogin, out UserRecord loggedInUser);

    public void UpdateRange(params UserRecord[] records);
  }
}
