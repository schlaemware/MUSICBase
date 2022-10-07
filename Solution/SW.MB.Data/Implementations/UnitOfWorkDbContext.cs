using Microsoft.EntityFrameworkCore;
using SW.MB.Data.Contracts;
using SW.MB.Data.Implementations.Abstractions;
using SW.MB.Data.Models.Entities;

namespace SW.MB.Data.Implementations {
  internal class UnitOfWorkDbContext : BaseDbContext, IUnitOfWork {
    public DbSet<CompositionEntity>? Compositions { get; set; }
    public DbSet<MandatorEntity>? Mandators { get; set; }

    #region IUNITOFWORK
    DbSet<CompositionEntity> IUnitOfWork.Compositions => Compositions 
      ?? throw new ApplicationException($"{nameof(UnitOfWorkDbContext)}.{nameof(Compositions)} not initialized!");

    DbSet<MandatorEntity> IUnitOfWork.Mandators => Mandators
      ?? throw new ApplicationException($"{nameof(UnitOfWorkDbContext)}.{nameof(Mandators)} not initialized!");
    #endregion IUNITOFWORK

    #region CONSTRUCTORS
    public UnitOfWorkDbContext(DbContextOptions<UnitOfWorkDbContext> options) : base(options) {
      Database.EnsureCreated();
    }
    #endregion CONSTRUCTORS

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
    }
  }
}
