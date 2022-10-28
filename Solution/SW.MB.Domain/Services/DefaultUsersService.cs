using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions.EntityExtensions;
using SW.MB.Domain.Extensions.RecordExtensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services
{
    internal class DefaultUsersService : ServiceBase, IUsersService {
        private readonly IUnitOfWork _UnitOfWork;

        #region CONSTRUCTORS
        public DefaultUsersService(IUnitOfWork uow) : base() {
            _UnitOfWork = uow;
        }
        #endregion CONSTRUCTORS

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
                    compositions.AddRange(GetAll(mandator));
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

        private IEnumerable<UserRecord> GetAll(MandatorRecord mandator) {
            MandatorEntity mandatorEntity = mandator.ToEntity();
            return _UnitOfWork.Users.Where(x => x.Mandators.Contains(mandatorEntity)).Select(x => x.ToRecord());
        }
    }
}
