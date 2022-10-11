﻿using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.UnitsOfWork;

[assembly: InternalsVisibleTo("DevConsole")]
[assembly: InternalsVisibleTo("SW.MB.Test")]

namespace SW.MB.Data
{
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

    public bool HasLicense { get; } = false;

    #region CONSTRUCTORS
    private DataFactory() {
      // empty...
    }
    #endregion CONSTRUCTORS

    public void ConfigureServices(IServiceCollection services) {
      if (HasLicense) {
        // Umsetzung als SQLite-Datenbank.
        services.AddDbContext<IUnitOfWork, UnitOfWorkDbContext>(options => options.UseSqlite("Data Source = C:\\Temporary\\MUSICBase.db"));
      } else {
        // Der In-Memory-Provider speichert keine Daten. Zusätzlich werden initial Musterdaten geladen.
        services.AddDbContext<IUnitOfWork, DemoUnitOfWorkDbContext>(options => options.UseInMemoryDatabase("DemoDB")
          .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
      }
    }
  }
}
