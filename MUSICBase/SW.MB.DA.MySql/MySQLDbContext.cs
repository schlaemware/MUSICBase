using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SW.MB.DA.Contracts.Repositories;
using SW.MB.DA.Contracts.Storages;
using SW.MB.DA.Implementations;

namespace SW.MB.DA.MySql {
  internal class MySQLDbContext : DbContextBase, IRemoteStorage, ICompositionsRepository, IMusiciansRepository {
    public const string CONNECTION_STRING_KEY = "MySQL";

    private readonly string _ConnectionString;

    #region CONSTRUCTORS
    public MySQLDbContext(IConfiguration appConfig) {
      _ConnectionString = appConfig.GetConnectionString(CONNECTION_STRING_KEY);
    }
    #endregion CONSTRUCTORS

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseMySql(_ConnectionString, new MariaDbServerVersion("10.3.35"));
    }
  }
}
