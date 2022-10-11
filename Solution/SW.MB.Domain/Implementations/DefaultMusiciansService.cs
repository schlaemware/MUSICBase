using Microsoft.Extensions.DependencyInjection;
using SW.MB.Data.Contracts;
using SW.MB.Domain.Contracts;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Implementations.Abstracts;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Implementations {
  internal class DefaultMusiciansService: ServiceBase, IMusiciansService {
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
