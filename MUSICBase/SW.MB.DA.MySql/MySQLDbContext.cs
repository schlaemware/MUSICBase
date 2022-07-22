using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SW.MB.DA.Contracts.Repositories;
using SW.MB.DA.Contracts.Storages;
using SW.MB.DA.Implementations;
using SW.MB.DA.Models.Records;

namespace SW.MB.DA.MySql {
    internal class MySQLDbContext : DbContextBase, IRemoteStorage, ICompositionsRepository, IMusiciansRepository {
        public const string CONNECTION_STRING_KEY = "MySQL";

        private readonly string _ConnectionString;

        public DbSet<CompositionRecord> CompositionRecords { get; set; }

        #region CONSTRUCTORS
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MySQLDbContext(IConfiguration appConfig) {
            _ConnectionString = appConfig.GetConnectionString(CONNECTION_STRING_KEY);
        }

        internal MySQLDbContext(string connectionString) {
            _ConnectionString=connectionString;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion CONSTRUCTORS

        #region ICOMPOSITIONSREPOSITORY
        List<CompositionRecord> ICompositionsRepository.GetAll() {
            return CompositionRecords.ToList();
        }
        #endregion ICOMPOSITIONSREPOSITORY

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(_ConnectionString, new MariaDbServerVersion("10.3.35"));
        }
    }
}
