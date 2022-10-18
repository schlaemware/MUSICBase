using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.UnitsOfWork;

namespace SW.MB.Test.UnitTests.UnitsOfWork {
    [TestClass]
    public class UnitOfWorkDbContextTests {
        private IUnitOfWork? _UnitOfWork;

        [TestInitialize]
        public void TestInit() {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly());
            UnitOfWorkDbContext uow = CreateUnitOfWork(builder.Build());
            uow.Database.EnsureDeleted();
            uow.Database.EnsureCreated();

            _UnitOfWork = uow;
        }

        [TestCleanup]
        public void TestCleanup() {
            (_UnitOfWork as UnitOfWorkDbContext)?.Database.EnsureDeleted();
        }

        [TestMethod]
        public void Count_Test() {
            int? compositions = _UnitOfWork?.Compositions.Count();

            Assert.IsNotNull(compositions);
        }

        private static UnitOfWorkDbContext CreateUnitOfWork(IConfiguration configuration) {
            MariaDbServerVersion serverVersion = new MariaDbServerVersion(new Version(10, 3));
            string connectionString = configuration.GetConnectionString("MySql");

            DbContextOptionsBuilder<UnitOfWorkDbContext> builder = new DbContextOptionsBuilder<UnitOfWorkDbContext>();
            builder.UseMySql(connectionString, serverVersion);

            return new UnitOfWorkDbContext(builder.Options);
        }
    }
}
