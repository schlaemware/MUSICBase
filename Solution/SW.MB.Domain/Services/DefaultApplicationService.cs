using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
  internal class DefaultApplicationService : ServiceBase, IApplicationService {
    #region CONSTRUCTORS
    public DefaultApplicationService(IServiceProvider serviceProvider) : base(serviceProvider) {
      // empty...
    }
    #endregion CONSTRUCTORS
  }
}
