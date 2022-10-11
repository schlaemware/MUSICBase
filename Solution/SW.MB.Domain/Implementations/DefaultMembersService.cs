using Microsoft.Extensions.DependencyInjection;
using SW.MB.Data.Contracts;
using SW.MB.Domain.Contracts;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Implementations.Abstracts;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Implementations {
  internal class DefaultMembersService: ServiceBase, IMembersService {
    #region CONSTRUCTORS
    public DefaultMembersService(IServiceProvider serviceProvider) : base(serviceProvider) {
      // empty...
    }
    #endregion CONSTRUCTORS

    public IEnumerable<MemberRecord> GetAll() {
      IUnitOfWork uow = ServiceProvider.GetRequiredService<IUnitOfWork>();
      return uow.Members.Select(x => x.ToRecord());
    }
  }
}
