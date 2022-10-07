using SW.MB.Domain.Contracts;
using SW.MB.Domain.Implementations.Abstracts;

namespace SW.MB.Domain.Implementations {
  internal class DefaultMandatorsService : ServiceBase, IMandatorsService {
    #region CONSTRUCTORS
    public DefaultMandatorsService(IServiceProvider serviceProvider) : base(serviceProvider) {
      System.Diagnostics.Debug.WriteLine($"{GetType().Name} created...");
    }
    #endregion CONSTRUCTORS
  }
}
