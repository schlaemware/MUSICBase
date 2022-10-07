using Microsoft.EntityFrameworkCore;

namespace SW.MB.Data.Implementations.Abstractions {
  internal abstract class BaseDbContext : DbContext {
    protected Serilog.ILogger Logger => Serilog.Log.Logger;

    #region CONSTRUCTORS
    public BaseDbContext(DbContextOptions options) : base(options) {
      // empty...
    }
    #endregion CONSTRUCTORS
  }
}
