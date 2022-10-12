using Microsoft.Extensions.DependencyInjection;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
    internal class DefaultMusiciansService : ServiceBase, IMusiciansService {
        #region CONSTRUCTORS
        public DefaultMusiciansService(IServiceProvider serviceProvider) : base(serviceProvider) {
            // empty...
        }
        #endregion CONSTRUCTORS

        public IEnumerable<MusicianRecord> GetAll() {
            IUnitOfWork uow = ServiceProvider.GetRequiredService<IUnitOfWork>();
            return uow.Musicians.Select(x => x.ToRecord());
        }
    }
}
