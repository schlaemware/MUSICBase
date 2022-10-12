using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
    internal class DefaultApplicationService : ServiceBase, IApplicationService {
        private IUnitOfWork _UnitOfWork;

        #region CONSTRUCTORS
        public DefaultApplicationService(IUnitOfWork uow) : base() {
            _UnitOfWork = uow;
        }
        #endregion CONSTRUCTORS
    }
}
