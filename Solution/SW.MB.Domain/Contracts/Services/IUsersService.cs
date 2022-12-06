﻿using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
  public interface IUsersService {
    public IEnumerable<UserRecord> GetAll();
    public IEnumerable<UserRecord> GetAll(params MandatorRecord?[]? mandators);

    public void UpdateRange(params UserRecord[] records);

    public bool VerifyPassword(string identifier, string password, out UserRecord? loggedInUser);
  }
}