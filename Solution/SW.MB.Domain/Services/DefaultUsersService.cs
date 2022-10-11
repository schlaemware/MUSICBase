using Microsoft.Extensions.DependencyInjection;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
  internal class DefaultUsersService: ServiceBase, IUsersService {
    #region CONSTRUCTORS
    public DefaultUsersService(IServiceProvider serviceProvider) : base(serviceProvider) {
      // empty...
    }
    #endregion CONSTRUCTORS

    public IEnumerable<UserRecord> GetAll() {
      IUnitOfWork uow = ServiceProvider.GetRequiredService<IUnitOfWork>();
      return uow.Users.Select(x => x.ToRecord());
    }
  }
}
