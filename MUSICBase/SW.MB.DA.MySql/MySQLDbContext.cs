using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SW.MB.DA.Contracts.Repositories;
using SW.MB.DA.Contracts.Storages;

[assembly: InternalsVisibleTo("SW.MB.UI.WPF")]

namespace SW.MB.DA.MySql {
  internal class MySQLDbContext : DbContext, IRemoteStorage, ICompositionsRepository, IMusiciansRepository {
    public const string CONNECTION_STRING_KEY = "MySQL";

    private readonly string _ConnectionString;

    public MySQLDbContext(IConfiguration appConfig) {
      _ConnectionString = appConfig[CONNECTION_STRING_KEY];
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseMySql(_ConnectionString, new MariaDbServerVersion("10.3.35"));
    }
  }
}
