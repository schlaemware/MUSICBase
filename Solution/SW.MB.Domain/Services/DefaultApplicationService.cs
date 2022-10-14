using Microsoft.EntityFrameworkCore.ChangeTracking;
using SW.Framework.Extensions;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
  internal class DefaultApplicationService: ServiceBase, IApplicationService {
    private IUnitOfWork _UnitOfWork;

    #region CONSTRUCTORS
    public DefaultApplicationService(IUnitOfWork uow) : base() {
      _UnitOfWork = uow;
    }
    #endregion CONSTRUCTORS

    public void GenerateSampleData() {
      Random random = new();

      GenerateSampleMandators(out List<MandatorEntity> mandators);
      GenerateSampleUsers(mandators, out List<UserEntity> users);
      GenerateSampleMembers(mandators, users, out List<MemberEntity> members);
      GenerateSampleMusicians(mandators, users, out List<MusicianEntity> musicians);
      GenerateSampleCompositions(mandators, users, musicians, out List<CompositionEntity> compositions);

      _UnitOfWork.SaveChangesAsync();
    }

    private void GenerateSampleCompositions(List<MandatorEntity> mandators, List<UserEntity> users, List<MusicianEntity> musicians, out List<CompositionEntity> compositions) {
      Random random = new();

      compositions = new();

      for (int n = 0; n < 50; n++) {
        CompositionEntity composition = new() {
          Created = DateTime.Today,
          CreatedBy = users[random.Next(users.Count)].ID,
          Updated = DateTime.Now,
          UpdatedBy = users[random.Next(users.Count)].ID,
          Title = random.NextTitle(),
          Mandators = new List<MandatorEntity>(),
        };

        composition.Mandators?.Add(mandators[random.Next(mandators.Count)]);

        var added = _UnitOfWork.Compositions.Add(composition);
        compositions.Add(added.Entity);
      }
    }

    private void GenerateSampleMandators(out List<MandatorEntity> mandators) {
      EntityEntry<MandatorEntity> manA = _UnitOfWork.Mandators.Add(new MandatorEntity() { Created = DateTime.Today, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Name = "Musikverein Berneck" });
      EntityEntry<MandatorEntity> manB = _UnitOfWork.Mandators.Add(new MandatorEntity() { Created = DateTime.Today, CreatedBy = 1, Updated = DateTime.Now, UpdatedBy = 1, Name = "Musikverein Balgach" });

      mandators = new() {
        manA.Entity,
        manB.Entity
      };
    }

    private void GenerateSampleMembers(List<MandatorEntity> mandators, List<UserEntity> users, out List<MemberEntity> members) {
      Random random = new();

      members = new();

      for (int n = 0; n < 20; n++) {
        MemberEntity member = new() {
          Created = DateTime.Today,
          CreatedBy = users[random.Next(users.Count)].ID,
          Updated = DateTime.Now,
          UpdatedBy = users[random.Next(users.Count)].ID,
          Firstname = random.NextFirstname(),
          Lastname = random.NextLastname(),
          Mandators = new List<MandatorEntity>(),
        };

        List<int> yearsOfJoining = new() { DateTime.Now.Year - random.Next(10) };
        List<int> yearsOfSeparation = new();

        while (random.NextBoolean()) {
          yearsOfSeparation.Add(yearsOfJoining.Last() - random.Next(1, 10));
          yearsOfJoining.Add(yearsOfSeparation.Last() - random.Next(1, 10));
        }

        member.DateOfBirth = random.NextDateTime(new DateTime(yearsOfJoining.Last() - 25, 1, 1), new DateTime(yearsOfJoining.Last() - 14, 12, 31));
        member.YearsOfJoining = string.Join(MemberRecordExtensions.JOIN_CHAR, yearsOfJoining);
        member.YearsOfSeparation = string.Join(MemberRecordExtensions.JOIN_CHAR, yearsOfSeparation);
        member.Mandators?.Add(mandators[random.Next(mandators.Count)]);

        var added = _UnitOfWork.Members.Add(member);
        members.Add(added.Entity);
      }
    }

    private void GenerateSampleMusicians(List<MandatorEntity> mandators, List<UserEntity> users, out List<MusicianEntity> musicians) {
      Random random = new();

      musicians = new();

      for (int n = 0; n < 20; n++) {
        MusicianEntity musician = new() {
          Created = DateTime.Today,
          CreatedBy = users[random.Next(users.Count)].ID,
          Updated = DateTime.Now,
          UpdatedBy = users[random.Next(users.Count)].ID,
          Firstname = random.NextFirstname(),
          Lastname = random.NextLastname(),
          Mandators = new List<MandatorEntity>(),
        };

        musician.DateOfBirth = random.NextDateTime(new DateTime(1000, 1, 1), new DateTime(DateTime.Now.Year - 20, 12, 31));
        if (musician.DateOfBirth < DateTime.Now.AddYears(-100) || (musician.DateOfBirth <= DateTime.Now.AddYears(-50) && random.NextBoolean())) {
          DateTime latestDeath = new(musician.DateOfBirth.Value.Year + 100, 12, 31);
          musician.DateOfDeath = random.NextDateTime(new DateTime(musician.DateOfBirth.Value.Year + 40, 1, 1),
            latestDeath > DateTime.Now ? DateTime.Now : latestDeath);
        }

        musician.Mandators?.Add(mandators[random.Next(mandators.Count)]);

        var added = _UnitOfWork.Musicians.Add(musician);
        musicians.Add(added.Entity);
      }
    }

    private void GenerateSampleUsers(List<MandatorEntity> mandators, out List<UserEntity> users) {
      Random random = new();

      users = new();

      for (int n = 0; n < 5; n++) {
        UserEntity user = new() {
          Created = DateTime.Today,
          CreatedBy = 1,
          Updated = DateTime.Now,
          UpdatedBy = 1,
          Firstname = random.NextFirstname(),
          Lastname = random.NextLastname(),
          DateOfBirth = random.NextDateTime(new DateTime(DateTime.Now.Year - 100, 1, 1), new DateTime(DateTime.Now.Year - 14, 12, 31)),
          Mandators = new List<MandatorEntity>(),
        };

        user.Mandators?.Add(mandators[random.Next(mandators.Count)]);

        var added = _UnitOfWork.Users.Add(user);
        users.Add(added.Entity);
      }
    }
  }
}
