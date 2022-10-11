using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SW.Framework.Extensions;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Data.UnitsOfWork.Abstractions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SW.MB.Data.UnitsOfWork {
  internal class DemoUnitOfWorkDbContext: BaseDbContext, IUnitOfWork {
    public const int NUM_OF_COMPOSITIONS = 10;
    public const int NUM_OF_MANDATORS = 3;
    public const int NUM_OF_MEMBERS = 10;
    public const int NUM_OF_MUSICIANS = 10;
    public const int NUM_OF_USERS = 5;

    private static readonly Random _Random = new();

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
      List<CompositionEntity> list = new();

      DateTime created;
      DateTime updated;

      for (int n = 0; n < NUM_OF_COMPOSITIONS; n++) {
        created = _Random.NextDateTimePast();
        updated = _Random.NextDateTimePast(created);

        list.Add(new CompositionEntity() {
          ID = n + 1,
          Created = created,
          CreatedBy = _Random.Next(1, NUM_OF_USERS + 1),
          Updated = updated,
          UpdatedBy = _Random.Next(1, NUM_OF_USERS + 1),
          Title = _Random.NextTitle(),
        });
      }

      return list;
    }

    private static List<MandatorEntity> GetMandators() {
      return new List<MandatorEntity>() {
        new MandatorEntity() { ID = 1, Created = _Random.NextDateTimePast(), CreatedBy = _Random.Next(1, NUM_OF_USERS + 1), Updated = _Random.NextDateTimePast(), UpdatedBy = _Random.Next(1, NUM_OF_USERS + 1), Name = "Musikverein Musterhausen" },
        new MandatorEntity() { ID = 2, Created = _Random.NextDateTimePast(), CreatedBy = _Random.Next(1, NUM_OF_USERS + 1), Updated = _Random.NextDateTimePast(), UpdatedBy = _Random.Next(1, NUM_OF_USERS + 1), Name = "Jodelchor Immerschwanger" },
        new MandatorEntity() { ID = 3, Created = _Random.NextDateTimePast(), CreatedBy = _Random.Next(1, NUM_OF_USERS + 1), Updated = _Random.NextDateTimePast(), UpdatedBy = _Random.Next(1, NUM_OF_USERS + 1), Name = "Jugendblasorchester Taubenuss" },
      };
    }

    private static List<MemberEntity> GetMembers() {
      List<MemberEntity> list = new();

      DateTime created;
      DateTime updated;

      for (int n = 0; n < NUM_OF_MEMBERS; n++) {
        created = _Random.NextDateTimePast();
        updated = _Random.NextDateTimePast(created);

        list.Add(new MemberEntity() {
          ID = n + 1,
          Created = created,
          CreatedBy = _Random.Next(1, NUM_OF_USERS + 1),
          Updated = updated,
          UpdatedBy = _Random.Next(1, NUM_OF_USERS + 1),
          Firstname = _Random.NextFirstname(),
          Lastname = _Random.NextLastname(),
          DateOfBirth = _Random.NextDateTimePast()
        });
      }

      return list;
    }

    private static List<MusicianEntity> GetMusicians() {
      List<MusicianEntity> list = new();

      DateTime created;
      DateTime updated;
      DateTime birthDate;
      DateTime? deathDate;

      for (int n = 0; n < NUM_OF_MUSICIANS; n++) {
        created = _Random.NextDateTimePast();
        updated = _Random.NextDateTimePast(created);
        birthDate = _Random.NextDateTimePast();
        deathDate = _Random.NextBoolean() ? _Random.NextDateTimePast(birthDate) : null;

        list.Add(new MusicianEntity() {
          ID = n + 1,
          Created = created,
          CreatedBy = _Random.Next(1, NUM_OF_USERS + 1),
          Updated = updated,
          UpdatedBy = _Random.Next(1, NUM_OF_USERS + 1),
          Firstname = _Random.NextFirstname(),
          Lastname = _Random.NextLastname(),
          DateOfBirth = birthDate,
          DateOfDeath = deathDate,
        });
      }

      return list;
    }

    private static List<UserEntity> GetUsers() {
      List<UserEntity> list = new();

      DateTime created;
      DateTime updated;
      string firstname;
      string lastname;

      for (int n = 0; n < NUM_OF_USERS; n++) {
        created = _Random.NextDateTimePast();
        updated = _Random.NextDateTimePast(created);
        firstname = _Random.NextFirstname();
        lastname = _Random.NextLastname();

        list.Add(new UserEntity() {
          ID = n + 1,
          Created = created,
          CreatedBy = _Random.Next(1, NUM_OF_USERS + 1),
          Updated = updated,
          UpdatedBy = _Random.Next(1, NUM_OF_USERS + 1),
          Firstname = firstname,
          Lastname = lastname,
          DateOfBirth = _Random.NextDateTimePast(),
          Mail = $"{firstname.ToLower()}.{lastname.ToLower()}@schlaemware.ch"
        });
      }

      return list;
    }
  }
}
