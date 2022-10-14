using Microsoft.EntityFrameworkCore;
using Serilog.Core;
using SW.MB.Data.Models.Entities;

namespace SW.MB.Data.UnitsOfWork.Abstractions {
  internal abstract class BaseDbContext: DbContext {
    protected Serilog.ILogger Logger => Serilog.Log.Logger;

    #region CONSTRUCTORS
    public BaseDbContext(DbContextOptions options) : base(options) {
      // empty...
    }
    #endregion CONSTRUCTORS

    public Task<int> SaveChangesAsync() {
      return base.SaveChangesAsync();
    }

    protected static UserEntity CreateSystemUser() {
      Serilog.Log.Logger.Information("Create system user...");
      return new UserEntity() {
        ID = 1,
        Created = DateTime.Now,
        CreatedBy = 1,
        Updated = DateTime.Now,
        UpdatedBy = 1,
        Firstname = "System",
        Lastname = "Administrator",
        Mail = "s@a",
      };
    }
  }
}
