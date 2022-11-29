using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Services.SampleDataServices {
  internal class SampleDataUsersService: IUsersService {
    public IEnumerable<UserRecord> GetAll() {
      Random random = new();
      int numOfUsers = random.Next(10, 100);
      List<UserRecord> users = new();
      for (int n = 0; n < numOfUsers; n++) {
        users.Add(new UserRecord() {
          Firstname = random.NextFirstname(),
          Lastname = random.NextLastname(),
          DateOfBirth = random.NextDateTimePast(),
        });
      }

      return users;
    }

    public IEnumerable<UserRecord> GetAll(params MandatorRecord?[]? mandators) {
      throw new NotImplementedException();
    }

    public UserRecord? GetLoggedInUser() {
      // TODO: throw new NotImplementedException();
      return default;
    }

    public void UpdateRange(params UserRecord[] records) {
      throw new NotImplementedException();
    }
  }
}
