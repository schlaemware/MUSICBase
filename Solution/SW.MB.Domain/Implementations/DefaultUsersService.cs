using Microsoft.Extensions.DependencyInjection;
using SW.MB.Data.Contracts;
using SW.MB.Domain.Contracts;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Implementations.Abstracts;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Implementations {
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
