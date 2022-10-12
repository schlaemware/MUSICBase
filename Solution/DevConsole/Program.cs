using Microsoft.EntityFrameworkCore;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.UnitsOfWork;

internal class Program {
    private static void Main(string[] args) {
        Console.WriteLine("Hello, MUSICBase!");

        IUnitOfWork uow = CreateUnitOfWork();

        Console.WriteLine($"Compositions: {uow.Compositions.Count()}");

        uow.Compositions.Add(new SW.MB.Data.Models.Entities.CompositionEntity() {
            ID = 1,
            Created = DateTime.Now,
            CreatedBy = 1,
            Updated = DateTime.Now,
            UpdatedBy = 1,
            Title = "Böhmischer Traum"
        });

        uow.Compositions.Add(new SW.MB.Data.Models.Entities.CompositionEntity() {
            ID = 2,
            Created = DateTime.Now,
            CreatedBy = 1,
            Updated = DateTime.Now,
            UpdatedBy = 1,
            Title = "The Lord Of The Dance"
        });

        //CompositionEntity entity = uow.Compositions.First();

        uow.SaveChanges();
    }

    private static IUnitOfWork CreateUnitOfWork() {
        MariaDbServerVersion serverVersion = new MariaDbServerVersion(new Version(10, 3));
        string connectionString = string.Empty;
        DbContextOptionsBuilder<UnitOfWorkDbContext> builder = new DbContextOptionsBuilder<UnitOfWorkDbContext>();
        builder.UseMySql(connectionString, serverVersion);

        UnitOfWorkDbContext uow = new UnitOfWorkDbContext(builder.Options);
        uow.Database.EnsureDeleted();
        uow.Database.EnsureCreated();

        return uow;
    }
}