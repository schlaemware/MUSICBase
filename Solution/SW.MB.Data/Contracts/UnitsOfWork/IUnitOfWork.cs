using Microsoft.EntityFrameworkCore;
using SW.MB.Data.Models.Entities;

namespace SW.MB.Data.Contracts.UnitsOfWork {
    public interface IUnitOfWork {
        public DbSet<CompositionEntity> Compositions { get; }
        public DbSet<MandatorEntity> Mandators { get; }
        public DbSet<MemberEntity> Members { get; }
        public DbSet<MusicianEntity> Musicians { get; }
        public DbSet<UserEntity> Users { get; }

        public int SaveChanges();
        public Task<int> SaveChangesAsync();
    }
}
