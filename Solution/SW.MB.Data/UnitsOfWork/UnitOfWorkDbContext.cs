using Microsoft.EntityFrameworkCore;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Data.UnitsOfWork.Abstractions;

namespace SW.MB.Data.UnitsOfWork
{
    internal class UnitOfWorkDbContext : BaseDbContext, IUnitOfWork {
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
    public UnitOfWorkDbContext(DbContextOptions<UnitOfWorkDbContext> options) : base(options) {
      Database.EnsureCreated();
    }
    #endregion CONSTRUCTORS

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
    }
  }
}
