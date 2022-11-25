using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions.EntityExtensions;
using SW.MB.Domain.Extensions.RecordExtensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
  internal class DefaultMusiciansService : DataServiceBase, IMusiciansService {
        private readonly IUnitOfWork _UnitOfWork;

        #region CONSTRUCTORS
        public DefaultMusiciansService(IUnitOfWork uow) : base() {
            _UnitOfWork = uow;
        }
        #endregion CONSTRUCTORS

        public IEnumerable<MusicianRecord> GetAll() {
            return _UnitOfWork.Musicians.Select(x => x.ToRecord());
        }

        public void UpdateRange(params MusicianRecord[] records) {
            foreach (MusicianRecord record in records) {
                if (_UnitOfWork.Musicians.SingleOrDefault(x => x.ID == record.ID) is MusicianEntity entity) {
                    SetAllProperties(entity, record.ToEntity());
                } else {
                    _UnitOfWork.Musicians.Add(record.ToEntity());
                }
            }

            _UnitOfWork.SaveChangesAsync();
        }
    }
}
