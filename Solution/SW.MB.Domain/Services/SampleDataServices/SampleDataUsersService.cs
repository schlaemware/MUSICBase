using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.SampleDataServices.Abstracts;

namespace SW.MB.Domain.Services.SampleDataServices {
  internal class SampleDataUsersService: SampleDataServiceBase<UserRecord>, IUsersDataService {
    public UserRecord? LoggedInUser { get; private set; }

    #region CONSTRUCTORS
    public SampleDataUsersService() : base() { }
    #endregion CONSTRUCTORS

    public bool TryLogIn(string name, string password, bool storeLogin, out UserRecord loggedInUser) {
      Random random = new();
      if (true) {
        loggedInUser = _RecordsDictionary.Values.ElementAt(random.Next(_RecordsDictionary.Count));

        return true;
      }

      loggedInUser = new();

      return false;
    }

    protected override void CreateSampleData() {
      Random random = new();
      int numOfUsers = random.Next(10, 100);
      
      for (int n = 1; n <= numOfUsers; n++) {
        _RecordsDictionary.Add(n, new UserRecord() {
          ID = n,
          Created = random.NextDateTimePast(),
          CreatedBy = random.Next(),
          Updated = random.NextDateTimePast(),
          UpdatedBy = random.Next(),
          Firstname = random.NextFirstname(),
          Lastname = random.NextLastname(),
          DateOfBirth = random.NextDateTimePast(),
        });
      }
    }
  }
}
