using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.UnitsOfWork;

[assembly: InternalsVisibleTo("DevConsole")]
[assembly: InternalsVisibleTo("SW.MB.Test")]

namespace SW.MB.Data {
    public sealed class DataFactory {
        public const string DEMO_DB_NAME = "DEMODatabase";

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
            string sqliteConnectionString = configuration.GetConnectionString("SQLite");

            // Wenn eine Lizenz vorhanden ist, sollte der Normalfall sein, dass über die MySQL-DB gearbeitet wird.
            // Für Spezialanwendungen (kein Internet) kann der Offline-Modus aktiviert sein. Dann wird sowohl die MySQL- als auch die SQLite-DB genutzt.

            // Nur Offline-Modus wird nicht unterstützt. Wäre ev. eine Möglichkeit für eine Demo-Version...ohne Synchronisierung nützt die Applikation nicht sonderlich viel.

            // Für lizenzfreien Modus wird ein Memory-Speicher bereitgestellt, welcher nach beenden der Applikation wieder gelöscht wird. Es können somit keine
            // Fortschritte gespeichert werden.

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
                if (!string.IsNullOrEmpty(sqliteConnectionString)) {
                    if (!sqliteConnectionString.StartsWith("Data Source =")) {
                        sqliteConnectionString = $"Data Source = {sqliteConnectionString}";
                    }

                    services.AddDbContext<IBackupUnitOfWork, UnitOfWorkDbContext>(options => options.UseSqlite(sqliteConnectionString));
                }
            } else if (!string.IsNullOrEmpty(sqliteConnectionString) && File.Exists(sqliteConnectionString)) {
                // Datenbank existiert bereits -> Offline-Modus
                services.AddDbContext<IUnitOfWork, UnitOfWorkDbContext>(options => options.UseSqlite(sqliteConnectionString));
            } else {
                // Umsetzung als Demo-Datenbank (volatile)
                services.AddDbContext<IUnitOfWork, UnitOfWorkDbContext>(options => options.UseInMemoryDatabase(DEMO_DB_NAME));
            }
        }
    }
}
