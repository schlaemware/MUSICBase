using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.UnitsOfWork;

[assembly: InternalsVisibleTo("DevConsole")]
[assembly: InternalsVisibleTo("SW.MB.Test")]

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

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration) {
            string mySqlConnectionString = configuration.GetConnectionString("MySql");

            if (!string.IsNullOrEmpty(mySqlConnectionString)) {
                MariaDbServerVersion serverVersion = new(new Version(10, 3));

#if DEBUG
                services.AddDbContext<IUnitOfWork, UnitOfWorkDbContext>(options => options.UseMySql(mySqlConnectionString, serverVersion)
                    // The following three options help with debugging, but should be changed or removed for production.
                    .LogTo(message => Serilog.Log.Logger.Information(message), Microsoft.Extensions.Logging.LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors());
#else
                services.AddDbContext<IUnitOfWork, UnitOfWorkDbContext>(options => options.UseMySql(mySqlConnectionString, serverVersion));
#endif
            } else {
                // Umsetzung als SQLite-Datenbank.
                services.AddDbContext<IUnitOfWork, UnitOfWorkDbContext>(options => options.UseSqlite("Data Source = C:\\Temporary\\MUSICBase.db"));
            }
        }
    }
}
