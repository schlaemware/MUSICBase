using Microsoft.EntityFrameworkCore;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Extensions.EntityExtensions;
using SW.MB.Domain.Extensions.RecordExtensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services
{
    internal class DefaultBandsService : ServiceBase, IBandsService {
        private readonly IUnitOfWork _UnitOfWork;

        #region CONSTRUCTORS
        public DefaultBandsService(IUnitOfWork uow) : base() {
            _UnitOfWork = uow;
        }
        #endregion CONSTRUCTORS

        public IEnumerable<BandRecord> GetAll() {
            return _UnitOfWork.Bands.Where(x => !x.Mandators.Any()).Include(x => x.Musicians).Select(x => x.ToRecord());
        }

        public IEnumerable<BandRecord> GetAll(params MandatorRecord?[]? mandators) {
            if (mandators == null || !mandators.Any(x => x != null)) {
                return GetAll();
            }

            List<BandRecord> bands = new();

            foreach (MandatorRecord? mandator in mandators) {
                if (mandator != null) {
                    bands.AddRange(GetAll(mandator));
                }
            }

            return bands;
        }

        public void Update(BandRecord record) {
            throw new NotImplementedException();
        }

        public void UpdateRange(params BandRecord[] records) {
            throw new NotImplementedException();
        }

        private IEnumerable<BandRecord> GetAll(MandatorRecord mandator) {
            MandatorEntity mandatorEntity = mandator.ToEntity();
            return _UnitOfWork.Bands.Where(x => x.Mandators.Contains(mandatorEntity)).Include(x => x.Musicians).Select(x => x.ToRecord());
        }
    }
}
