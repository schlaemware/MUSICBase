using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Services;

[assembly: InternalsVisibleTo("DevConsole")]
[assembly: InternalsVisibleTo("SW.MB.Test")]

namespace SW.MB.Domain
{
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

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration) {
      services.AddTransient<IApplicationService, DefaultApplicationService>();
      services.AddTransient<ICompositionsService, DefaultCompositionsService>();
      services.AddTransient<IMandatorsService, DefaultMandatorsService>();
      services.AddTransient<IMembersService, DefaultMembersService>();
      services.AddTransient<IMusiciansService, DefaultMusiciansService>();
      services.AddTransient<IUsersService, DefaultUsersService>();
    }
  }
}
