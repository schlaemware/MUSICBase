using SW.Framework.Security;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions.EntityExtensions;
using SW.MB.Domain.Extensions.RecordExtensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
  internal class DefaultUsersService: DataServiceBase, IUsersService {
    private readonly IUnitOfWork _UnitOfWork;

    #region CONSTRUCTORS
    public DefaultUsersService(IUnitOfWork uow) : base() {
      _UnitOfWork = uow;
    }
    #endregion CONSTRUCTORS

    #region PUBLIC METHODS
    public IEnumerable<UserRecord> GetAll() {
      return _UnitOfWork.Users.Where(x => !x.Mandators.Any()).Select(x => x.ToRecord());
    }

    public IEnumerable<UserRecord> GetAll(params MandatorRecord?[]? mandators) {
      if (mandators == null || !mandators.Any(x => x != null)) {
        return GetAll();
      }

      List<UserRecord> compositions = new();

      foreach (MandatorRecord? mandator in mandators) {
        if (mandator != null) {
          compositions.AddRange(GetAllByMandator(mandator));
        }
      }

      return compositions;
    }

    public void UpdateRange(params UserRecord[] records) {
      foreach (UserRecord record in records) {
        if (_UnitOfWork.Users.SingleOrDefault(x => x.ID == record.ID) is UserEntity entity) {
          SetAllProperties(entity, record.ToEntity());
        } else {
          _UnitOfWork.Users.Add(record.ToEntity());
        }
      }

      _UnitOfWork.SaveChangesAsync();
    }

    public bool VerifyPassword(string identifier, string password, out UserRecord? loggedInUser) {
      UserEntity? entity = _UnitOfWork.Users.FirstOrDefault(x => x.Username == identifier);
      entity ??= _UnitOfWork.Users.FirstOrDefault(x => x.Mail == identifier);

      if (entity != null && !string.IsNullOrEmpty(entity.PasswordHash)) {
        PasswordHasher hasher = new(new HashingOptions(DateTime.UtcNow.Year + DateTime.UtcNow.Month + DateTime.UtcNow.Day));
        (bool verified, bool needsUpdate) = hasher.Check(entity.PasswordHash, password);

        loggedInUser = verified ? entity.ToRecord() : null;

        return verified;
      }

      loggedInUser = null;

      return false;
    }
    #endregion PUBLIC METHODS

    private IEnumerable<UserRecord> GetAllByMandator(MandatorRecord mandator) {
      MandatorEntity mandatorEntity = mandator.ToEntity();
      return _UnitOfWork.Users.Where(x => x.Mandators.Contains(mandatorEntity)).Select(x => x.ToRecord());
    }
  }
}
