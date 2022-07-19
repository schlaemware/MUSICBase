using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SW.MB.DA.Contracts.Repositories;
using SW.MB.DA.Contracts.Storages;

[assembly: InternalsVisibleTo("SW.MB.UI.WPF")]

namespace SW.MB.DA.Sqlite {
  internal class SQLiteDbContext : DbContext, ILocalStorage, ICompositionsRepository, IMusiciansRepository {
    public const string CONNECTION_STRING_KEY = "SQLite";

    private readonly string _ConnectionString;

    public SQLiteDbContext(IConfiguration appConfig) {
      _ConnectionString = appConfig.GetConnectionString(CONNECTION_STRING_KEY);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite(_ConnectionString.StartsWith("Data Source=")
        ? _ConnectionString
        : $"Data Source={_ConnectionString}");
    }
  }
}
