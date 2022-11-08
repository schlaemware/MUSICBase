using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions.EntityExtensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
  internal class DefaultBandsService : ServiceBase, IBandsService {
        private readonly IUnitOfWork _UnitOfWork;

        #region CONSTRUCTORS
        public DefaultBandsService(IUnitOfWork uow) : base() {
            _UnitOfWork = uow;
        }
        #endregion CONSTRUCTORS

        public IEnumerable<BandRecord> GetAll() {
            return _UnitOfWork.Bands.Select(x => x.ToRecord());
        }

        public void Update(BandRecord record) {
            throw new NotImplementedException();
        }

        public void UpdateRange(params BandRecord[] records) {
            throw new NotImplementedException();
        }
    }
}
