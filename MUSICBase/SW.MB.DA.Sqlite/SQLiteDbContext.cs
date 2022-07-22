using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SW.MB.DA.Contracts.Repositories;
using SW.MB.DA.Contracts.Storages;
using SW.MB.DA.Implementations;
using SW.MB.DA.Models.Records;

namespace SW.MB.DA.Sqlite {
  internal class SQLiteDbContext : DbContextBase, ILocalStorage, ICompositionsRepository, IMusiciansRepository {
    public const string CONNECTION_STRING_KEY = "SQLite";

    private readonly Version _AppVersion;
    private readonly string _ConnectionString;

    public DbSet<CompositionRecord> CompositionRecords { get; set; }
    
    public string FilePath { get; private set; }

    #region CONSTRUCTORS
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SQLiteDbContext(IConfiguration appConfig) {
      _AppVersion = Version.TryParse(appConfig[typeof(Version).FullName], out Version? version) ? version : new Version();
      _ConnectionString = appConfig.GetConnectionString(CONNECTION_STRING_KEY);
    }

    /// <summary>
    /// Test constructor
    /// </summary>
    /// <param name="connectionString"></param>
    internal SQLiteDbContext(string connectionString) {
      _AppVersion = new Version();
      _ConnectionString = connectionString;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion CONSTRUCTORS

    public int Count<T>() where T : class {
      if (typeof(T) == typeof(CompositionRecord)) {
        return CompositionRecords.Count();
      }

      return 0;
    }

    public T? Get<T>(int id) where T : class {
      if (typeof(T) == typeof(CompositionRecord)) {
        return CompositionRecords.FirstOrDefault(x => x.ID == id) as T;
      }

      return null;
    }

    public T? Insert<T>(T entity) where T : EntityRecord {
      Database.EnsureCreated();
      T? newEntity = null;

      switch (entity) {
        case CompositionRecord compositionRecord:
          newEntity = CompositionRecords.Add(compositionRecord).Entity as T;
          break;

        default:
          throw new ApplicationException();
      }

      SaveChanges();

      return newEntity;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      FilePath = _ConnectionString.StartsWith("Data Source=")
        ? _ConnectionString.Substring(_ConnectionString.IndexOf('=') + 1)
        : _ConnectionString;

      if (!Path.IsPathFullyQualified(FilePath)) {
        throw new InvalidOperationException($"ConnectionString {FilePath} defines not a valid file path!");
      }

      FilePath = Path.Join(Path.GetDirectoryName(FilePath), $"{Path.GetFileNameWithoutExtension(FilePath)}_{_AppVersion}.db");

      optionsBuilder.UseSqlite($"Data Source=\"{FilePath}\"");
    }
  }
}
