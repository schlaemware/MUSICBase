using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
    internal class DefaultMusiciansService : ServiceBase, IMusiciansService {
        private readonly IUnitOfWork _UnitOfWork;

        #region CONSTRUCTORS
        public DefaultMusiciansService(IUnitOfWork uow) : base() {
            _UnitOfWork = uow;
        }
        #endregion CONSTRUCTORS

        public IEnumerable<MusicianRecord> GetAll() {
            return _UnitOfWork.Musicians.Where(x => !x.Mandators.Any()).Select(x => x.ToRecord());
        }

        public IEnumerable<MusicianRecord> GetAll(params MandatorRecord?[]? mandators) {
            if (mandators == null || !mandators.Any(x => x != null)) {
                return GetAll();
            }

            List<MusicianRecord> compositions = new();

            foreach (MandatorRecord? mandator in mandators) {
                if (mandator != null) {
                    compositions.AddRange(GetAll(mandator));
                }
            }

            return compositions;
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

        private IEnumerable<MusicianRecord> GetAll(MandatorRecord mandator) {
            MandatorEntity mandatorEntity = mandator.ToEntity();
            return _UnitOfWork.Musicians.Where(x => x.Mandators.Contains(mandatorEntity)).Select(x => x.ToRecord());
        }
    }
}
