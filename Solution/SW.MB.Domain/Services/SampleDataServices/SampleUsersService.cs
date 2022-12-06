using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.SampleDataServices.Abstracts;

namespace SW.MB.Domain.Services.SampleDataServices {
  internal class SampleUsersService: SampleDataServiceBase<UserRecord>, IUsersService {
    public UserRecord? LoggedInUser { get; private set; }

    #region CONSTRUCTORS
    public SampleUsersService() : base() {

    }
    #endregion CONSTRUCTORS

    public bool VerifyPassword(string identifier, string password, out UserRecord? loggedInUser) {
      Task.Delay(3000).Wait();

      if (!string.IsNullOrEmpty(identifier) && !string.IsNullOrEmpty(password) && password.Length >= 3) {
        loggedInUser = _RecordsDictionary.ElementAt(new Random().Next(_RecordsDictionary.Count)).Value;

        return true;
      }

      loggedInUser = null;

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
