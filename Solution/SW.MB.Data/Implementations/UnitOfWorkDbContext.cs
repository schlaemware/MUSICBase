using Microsoft.EntityFrameworkCore;
using SW.MB.Data.Contracts;
using SW.MB.Data.Models.Entities;

namespace SW.MB.Data.Implementations {
  internal class UnitOfWorkDbContext : DbContext, IUnitOfWork {
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
      //modelBuilder.Entity<CompositionEntity>().HasData(GetCompositions());
      //modelBuilder.Entity<MandatorEntity>().HasData(GetMandators());

      base.OnModelCreating(modelBuilder);
    }

    private List<CompositionEntity> GetCompositions() {
      return new List<CompositionEntity>() {
        new CompositionEntity() { ID = 1, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "First Title" },
        new CompositionEntity() { ID = 2, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "Second Title" },
        new CompositionEntity() { ID = 3, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "Third Title" },
        new CompositionEntity() { ID = 4, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "Fourth Title" },
        new CompositionEntity() { ID = 5, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "Fifth Title" },
      };
    }

    private List<MandatorEntity> GetMandators() {
      return new List<MandatorEntity>() {
        new MandatorEntity() { ID = 1, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Name = "First Mandator" },
        new MandatorEntity() { ID = 2, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Name = "Second Mandator" },
        new MandatorEntity() { ID = 3, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Name = "Third Mandator" },
      };
    }
  }
}
