using Microsoft.EntityFrameworkCore;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Configurations;
using SW.MB.Data.Models.Entities;
using SW.MB.Data.UnitsOfWork.Abstractions;

namespace SW.MB.Data.UnitsOfWork {
    internal class UnitOfWorkDbContext : BaseDbContext, IUnitOfWork, IBackupUnitOfWork {
        public DbSet<BandEntity>? Bands { get; set; }
        public DbSet<CompositionEntity>? Compositions { get; set; }
        public DbSet<ConcertProgramEntity>? ConcertPrograms { get; set; }
        public DbSet<FormationEntity>? Formations { get; set; }
        public DbSet<MandatorEntity>? Mandators { get; set; }
        public DbSet<MemberEntity>? Members { get; set; }
        public DbSet<MusicianEntity>? Musicians { get; set; }
        public DbSet<RepertoireProgramEntity>? RepertoirePrograms { get; set; }
        public DbSet<UserEntity>? Users { get; set; }

        #region IUNITOFWORK
        DbSet<BandEntity> IUnitOfWork.Bands => Bands
            ?? throw new ApplicationException($"{GetType().Name}.{nameof(Bands)} not initialized!");

        DbSet<ConcertProgramEntity> IUnitOfWork.ConcertPrograms => ConcertPrograms
          ?? throw new ApplicationException($"{GetType().Name}.{nameof(ConcertPrograms)} not initialized!");

        DbSet<CompositionEntity> IUnitOfWork.Compositions => Compositions
            ?? throw new ApplicationException($"{GetType().Name}.{nameof(Compositions)} not initialized!");

        DbSet<MandatorEntity> IUnitOfWork.Mandators => Mandators
            ?? throw new ApplicationException($"{GetType().Name}.{nameof(Mandators)} not initialized!");

        DbSet<MemberEntity> IUnitOfWork.Members => Members
            ?? throw new ApplicationException($"{GetType().Name}.{nameof(Members)} not initialized!");

        DbSet<MusicianEntity> IUnitOfWork.Musicians => Musicians
            ?? throw new ApplicationException($"{GetType().Name}.{nameof(Musicians)} not initialized!");

        DbSet<RepertoireProgramEntity> IUnitOfWork.RepertoirePrograms => RepertoirePrograms
          ?? throw new ApplicationException($"{GetType().Name}.{nameof(RepertoirePrograms)} not initialized!");

        DbSet<UserEntity> IUnitOfWork.Users => Users
            ?? throw new ApplicationException($"{GetType().Name}.{nameof(Users)} not initialized!");
        #endregion IUNITOFWORK

        #region CONSTRUCTORS
        public UnitOfWorkDbContext(DbContextOptions<UnitOfWorkDbContext> options) : base(options) {
            if (true || Database.IsSqlite()) {
                Database.EnsureCreated();
            }
        }
        #endregion CONSTRUCTORS

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            new BandEntityConfiguration().Configure(modelBuilder.Entity<BandEntity>());
            new CompositionEntityConfiguration().Configure(modelBuilder.Entity<CompositionEntity>());
            new ConcertProgramEntityConfiguration().Configure(modelBuilder.Entity<ConcertProgramEntity>());
            new FormationEntityEntityConfiguration().Configure(modelBuilder.Entity<FormationEntity>());
            new MandatorEntityEntityConfiguration().Configure(modelBuilder.Entity<MandatorEntity>());
            new MemberEntityEntityConfiguration().Configure(modelBuilder.Entity<MemberEntity>());
            new MusicianEntityEntityConfiguration().Configure(modelBuilder.Entity<MusicianEntity>());
            new RepertoireProgramEntityEntityConfiguration().Configure(modelBuilder.Entity<RepertoireProgramEntity>());
            new UserEntityConfiguration().Configure(modelBuilder.Entity<UserEntity>());
        }
    }
}
