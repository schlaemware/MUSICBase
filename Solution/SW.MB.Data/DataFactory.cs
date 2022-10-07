using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Data.Contracts;
using SW.MB.Data.Implementations;

[assembly: InternalsVisibleTo("DevConsole")]

namespace SW.MB.Data {
  public sealed class DataFactory {
    private static readonly object _LockObject = new();
    private static DataFactory? _Instance;

    public static DataFactory Instance {
      get {
        if (_Instance == null) {
          lock (_LockObject) {
            _Instance ??= new DataFactory();
          }
        }

        return _Instance;
      }
    }

    #region CONSTRUCTORS
    private DataFactory() {
      // empty...
    }
    #endregion CONSTRUCTORS

    public void ConfigureServices(ServiceCollection services) {
      services.AddDbContext<IUnitOfWork, UnitOfWorkDbContext>(options => options.UseSqlite("Data Source = C:\\Temporary\\MUSICBase.db"));
    }
  }
}
