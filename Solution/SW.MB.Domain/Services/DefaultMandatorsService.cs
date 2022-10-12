using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
    internal class DefaultMandatorsService : ServiceBase, IMandatorsService {
        private readonly IUnitOfWork _UnitOfWork;

        #region CONSTRUCTORS
        public DefaultMandatorsService(IUnitOfWork uow) : base() {
            _UnitOfWork = uow;
        }
        #endregion CONSTRUCTORS

        public IEnumerable<MandatorRecord> GetAll() {
            return _UnitOfWork.Mandators.Select(x => x.ToRecord());
        }

        public void UpdateRange(params MandatorRecord[] records) {
            foreach (MandatorRecord record in records) {
                if (_UnitOfWork.Mandators.SingleOrDefault(x => x.ID == record.ID) is MandatorEntity entity) {
                    SetAllProperties(entity, record.ToEntity());
                } else {
                    _UnitOfWork.Mandators.Add(record.ToEntity());
                }
            }

            _UnitOfWork.SaveChangesAsync();
        }
    }
}
