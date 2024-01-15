using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SW.MB.Domain.Entities;
using SW.MB.Domain.Shared;

namespace SW.MB.EFCore.EFCore {
    public class MUSICBaseDbContext : DbContext {
        public static readonly MariaDbServerVersion SERVER_VERSION = new MariaDbServerVersion(new Version(10, 6));

        private readonly MUSICBaseConfiguration _configuration;

        public DbSet<Composition> Compositions { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Musician> Musicians { get; set; }

        public MUSICBaseDbContext(DbContextOptions<MUSICBaseDbContext> options, MUSICBaseConfiguration configuration) : base(options) {
            _configuration = configuration;

            if (Database.IsSqlite()) {
                Database.EnsureDeleted();
            }

            if (!Database.EnsureCreated()) {
                Database.Migrate();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!string.IsNullOrEmpty(_configuration.MySQLConnectionString)) {
                optionsBuilder.UseMySql(_configuration.MySQLConnectionString, SERVER_VERSION);
            }
            else {
                optionsBuilder.UseSqlite($"DataSource = {Path.Combine(_configuration.ApplicationDirectory.FullName, "MUSICBase.db")}");
            }
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
