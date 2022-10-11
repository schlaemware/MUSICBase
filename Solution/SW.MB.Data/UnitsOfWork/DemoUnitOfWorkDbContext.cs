using Microsoft.EntityFrameworkCore;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Data.UnitsOfWork.Abstractions;

namespace SW.MB.Data.UnitsOfWork
{
    internal class DemoUnitOfWorkDbContext: BaseDbContext, IUnitOfWork {
    public DbSet<CompositionEntity>? Compositions { get; set; }
    public DbSet<MandatorEntity>? Mandators { get; set; }
    public DbSet<MemberEntity>? Members { get; set; }
    public DbSet<MusicianEntity>? Musicians { get; set; }
    public DbSet<UserEntity>? Users { get; set; }

    #region IUNITOFWORK
    DbSet<CompositionEntity> IUnitOfWork.Compositions => Compositions
      ?? throw new ApplicationException($"{GetType().Name}.{nameof(Compositions)} not initialized!");

    DbSet<MandatorEntity> IUnitOfWork.Mandators => Mandators
      ?? throw new ApplicationException($"{GetType().Name}.{nameof(Mandators)} not initialized!");

    DbSet<MemberEntity> IUnitOfWork.Members => Members
      ?? throw new ApplicationException($"{GetType().Name}.{nameof(Members)} not initialized!");

    DbSet<MusicianEntity> IUnitOfWork.Musicians => Musicians
      ?? throw new ApplicationException($"{GetType().Name}.{nameof(Musicians)} not initialized!");

    DbSet<UserEntity> IUnitOfWork.Users => Users
      ?? throw new ApplicationException($"{GetType().Name}.{nameof(Users)} not initialized!");
    #endregion IUNITOFWORK

    #region CONSTRUCTORS
    public DemoUnitOfWorkDbContext(DbContextOptions<DemoUnitOfWorkDbContext> options) : base(options) {
      Database.EnsureDeleted();
      Database.EnsureCreated();
    }
    #endregion CONSTRUCTORS

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<CompositionEntity>().HasData(GetCompositions());
      modelBuilder.Entity<MandatorEntity>().HasData(GetMandators());
      modelBuilder.Entity<MemberEntity>().HasData(GetMembers());
      modelBuilder.Entity<MusicianEntity>().HasData(GetMusicians());
      modelBuilder.Entity<UserEntity>().HasData(GetUsers());

      base.OnModelCreating(modelBuilder);
    }

    private List<CompositionEntity> GetCompositions() {
      return new List<CompositionEntity>() {
        new CompositionEntity() { ID = 1, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "First Title" },
        new CompositionEntity() { ID = 2, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "Second Title" },
        new CompositionEntity() { ID = 3, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "Third Title" },
        new CompositionEntity() { ID = 4, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "Fourth Title" },
        new CompositionEntity() { ID = 5, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "Fifth Title" },
        new CompositionEntity() { ID = 6, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "Sixth Title" },
        new CompositionEntity() { ID = 7, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Title = "Seventh Title" },
      };
    }

    private static List<MandatorEntity> GetMandators() {
      return new List<MandatorEntity>() {
        new MandatorEntity() { ID = 1, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Name = "First Mandator" },
        new MandatorEntity() { ID = 2, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Name = "Second Mandator" },
        new MandatorEntity() { ID = 3, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Name = "Third Mandator" },
      };
    }

    private static List<MemberEntity> GetMembers() {
      return new List<MemberEntity>() {
        new MemberEntity() { ID = 1, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Firstname = "Max", Lastname = "Muster" },
      };
    }

    private static List<MusicianEntity> GetMusicians() {
      return new List<MusicianEntity>() {
        new MusicianEntity() { ID = 1, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Firstname = "Hans", Lastname = "Zimmer" },
      };
    }

    private static List<UserEntity> GetUsers() {
      return new List<UserEntity>() {
        new UserEntity() { ID = 1, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Firstname = "Michael", Lastname = "Schläpfer" },
        new UserEntity() { ID = 2, Created = DateTime.Now, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Firstname = "Svenja", Lastname = "Wick" }
      };
    }
  }
}
