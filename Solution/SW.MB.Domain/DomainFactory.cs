using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Services;
using SW.MB.Domain.Services.SampleDataServices;

[assembly: InternalsVisibleTo("DevConsole")]
[assembly: InternalsVisibleTo("SW.MB.Test")]

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

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration) {
      services.AddTransient<IBandsDataService, DefaultBandsDataService>();
      services.AddTransient<ICompositionsDataService, DefaultCompositionsDataService>();
      services.AddTransient<IFileService, FileService>();
      //services.AddTransient<IMandatorsService, DefaultMandatorsService>();
      services.AddTransient<IMandatorsDataService, SampleDataMandatorsService>();
      //services.AddTransient<IMembersService, DefaultMembersService>();
      services.AddTransient<IMembersDataService, SampleDataMembersService>();
      //services.AddTransient<IMusiciansService, DefaultMusiciansService>();
      services.AddTransient<IMusiciansDataService, SampleDataMusiciansService>();
      //services.AddTransient<IUpdatesService, DefaultUpdatesService>();
      services.AddTransient<IUpdatesDataService, SampleDataUpdatesService>();
      //services.AddTransient<IUsersService, DefaultUsersService>();
      services.AddTransient<IUsersDataService, SampleDataUsersService>();
    }
  }
}
