using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Domain.Contracts;
using SW.MB.Domain.Implementations;

[assembly: InternalsVisibleTo("DevConsole")]

namespace SW.MB.Domain {
  public sealed class DomainFactory {
    private static readonly object _LockObject = new();
    private static DomainFactory? _Instance;

    public static DomainFactory Instance {
      get {
        if (_Instance == null) {
          lock (_LockObject) {
            _Instance ??= new DomainFactory();
          }
        }

        return _Instance;
      }
    }

    #region CONSTRUCTORS
    private DomainFactory() {
      // empty...
    }
    #endregion CONSTRUCTORS

    public void ConfigureServices(ServiceCollection services) {
      services.AddTransient<ICompositionsService, DefaultCompositionsService>();
      services.AddTransient<IMandatorsService, DefaultMandatorsService>();
    }
  }
}
