using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions.EntityExtensions;
using SW.MB.Domain.Extensions.RecordExtensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
  internal class DefaultCompositionsService : DataServiceBase, ICompositionsService {
        private readonly IUnitOfWork _UnitOfWork;

        #region CONSTRUCTORS
        public DefaultCompositionsService(IUnitOfWork uow) : base() {
            _UnitOfWork = uow;
        }
        #endregion CONSTRUCTORS

        public IEnumerable<CompositionRecord> GetAll(params MandatorRecord?[]? mandators) {
            if (mandators == null || !mandators.Any(x => x != null)) {
                return new List<CompositionRecord>();
            }

            List<CompositionRecord> compositions = new();

            foreach (MandatorRecord? mandator in mandators) {
                if (mandator != null) {
                    compositions.AddRange(GetAllByMandatorID(mandator.ID));
                }
            }

            return compositions;
        }

        public void Update(CompositionRecord record) {
            SetAllProperties(_UnitOfWork.Compositions.SingleOrDefault(x => x.ID == record.ID), record.ToEntity());
            _UnitOfWork.SaveChanges();
        }

        public void UpdateRange(params CompositionRecord[] records) {
            foreach (CompositionRecord record in records) {
                if (_UnitOfWork.Compositions.SingleOrDefault(x => x.ID == record.ID) is CompositionEntity entity) {
                    SetAllProperties(entity, record.ToEntity());
                } else {
                    _UnitOfWork.Compositions.Add(record.ToEntity());
                }
            }

            _UnitOfWork.SaveChangesAsync();
        }

        private IEnumerable<CompositionRecord> GetAllByMandatorID(int mandatorID) {
            return _UnitOfWork.Compositions.Where(x => x.Mandator.ID == mandatorID).Select(x => x.ToRecord());
        }
    }
}
