using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SW.Framework.Extensions;
using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
    internal class DefaultApplicationService : ServiceBase, IApplicationService {
        public const int NUM_OF_COMPOSITIONS_PER_MANDATOR = 50;
        public const int NUM_OF_MEMBERS_PER_MANDATOR = 20;
        public const int NUM_OF_MUSICIANS_PER_MANDATOR = 20;
        public const int NUM_OF_USERS_PER_MANDATOR = 3;

        private IUnitOfWork _UnitOfWork;

        #region CONSTRUCTORS
        public DefaultApplicationService(IUnitOfWork uow) : base() {
            _UnitOfWork = uow;
        }
        #endregion CONSTRUCTORS

        public void GenerateSampleData() {
            GenerateSampleMandator(out MandatorEntity mandator, "Musikverein Berneck");
            GenerateSampleUsers(mandator, out List<UserEntity> users);
            GenerateSampleMusicians(mandator, users, out List<MusicianEntity> musicians);
            GenerateSampleCompositions(mandator, users, musicians, out List<CompositionEntity> compositions);
            GenerateSampleMembers(mandator, users, out List<MemberEntity> members);

            GenerateSampleMandator(out mandator, "Musikverein Balgach");
            GenerateSampleUsers(mandator, out users);
            GenerateSampleMusicians(mandator, users, out musicians);
            GenerateSampleCompositions(mandator, users, musicians, out compositions);
            GenerateSampleMembers(mandator, users, out members);

            GenerateSampleMandator(out mandator, "Musikverein Heerbrugg");
            GenerateSampleUsers(mandator, out users);
            GenerateSampleMusicians(mandator, users, out musicians);
            GenerateSampleCompositions(mandator, users, musicians, out compositions);
            GenerateSampleMembers(mandator, users, out members);

            _UnitOfWork.SaveChangesAsync();

            IMandatorsService.RaiseMandatorsChanged();
        }

        private void GenerateSampleCompositions(MandatorEntity mandator, List<UserEntity> users, List<MusicianEntity> musicians, out List<CompositionEntity> compositions) {
            Random random = new();
            compositions = new();

            for (int n = 0; n < NUM_OF_COMPOSITIONS_PER_MANDATOR; n++) {
                CompositionEntity composition = CreateCompositionEntity();
                composition.Mandators.Add(mandator);
                composition.CreatedBy = users[random.Next(users.Count)].ID;
                composition.UpdatedBy = users[random.Next(users.Count)].ID;

                EntityEntry<CompositionEntity> added = _UnitOfWork.Compositions.Add(composition);
                compositions.Add(added.Entity);
            }
        }

        private void GenerateSampleMandator(out MandatorEntity mandator, string? name) {
            EntityEntry<MandatorEntity> added = _UnitOfWork.Mandators.Add(CreateMandatorEntity(name));
            mandator = added.Entity;
        }

        private void GenerateSampleMembers(MandatorEntity mandator, List<UserEntity> users, out List<MemberEntity> members) {
            Random random = new();
            members = new();

            for (int n = 0; n < NUM_OF_MEMBERS_PER_MANDATOR; n++) {
                MemberEntity member = CreateMemberEntity();
                member.Mandators.Add(mandator);
                member.CreatedBy = users[random.Next(users.Count)].ID;
                member.UpdatedBy = users[random.Next(users.Count)].ID;

                EntityEntry<MemberEntity> added = _UnitOfWork.Members.Add(member);
                members.Add(added.Entity);
            }
        }

        private void GenerateSampleMusicians(MandatorEntity mandator, List<UserEntity> users, out List<MusicianEntity> musicians) {
            Random random = new();
            musicians = new();

            for (int n = 0; n < NUM_OF_MUSICIANS_PER_MANDATOR; n++) {
                MusicianEntity musician = CreateMusicianEntity();
                musician.Mandators.Add(mandator);
                musician.CreatedBy = users[random.Next(users.Count)].ID;
                musician.UpdatedBy = users[random.Next(users.Count)].ID;

                EntityEntry<MusicianEntity> added = _UnitOfWork.Musicians.Add(musician);
                musicians.Add(added.Entity);

                if (random.NextBoolean()) {
                    musician = CreatePseudonym(added.Entity);
                    musician.Mandators.Add(mandator);
                    musician.CreatedBy = musician.CreatedBy;
                    musician.UpdatedBy = musician.UpdatedBy;

                    EntityEntry<MusicianEntity> addedPseudonym = _UnitOfWork.Musicians.Add(musician);
                    musicians.Add(addedPseudonym.Entity);
                }
            }
        }

        private void GenerateSampleUsers(MandatorEntity mandator, out List<UserEntity> users) {
            users = new();

            for (int n = 0; n < NUM_OF_USERS_PER_MANDATOR; n++) {
                UserEntity user = CreateUserEntity();
                user.Mandators.Add(mandator);

                EntityEntry<UserEntity> added = _UnitOfWork.Users.Add(user);
                users.Add(added.Entity);
            }
        }

        #region CREATE SAMPLE ENTITIES
        private static CompositionEntity CreateCompositionEntity() {
            Random random = new();
            DateTime temp = DateTime.Now;

            return new CompositionEntity() {
                Created = temp,
                CreatedBy = 1,
                Updated = temp,
                UpdatedBy = 1,
                Title = random.NextTitle(),
            };
        }

        private static MandatorEntity CreateMandatorEntity(string? name) {
            Random random = new();
            DateTime temp = DateTime.Now;

            return new MandatorEntity() {
                Created = temp,
                CreatedBy = 1,
                Updated = temp,
                UpdatedBy = 1,
                Name = name ?? random.NextTitle(),
            };
        }

        private static MemberEntity CreateMemberEntity() {
            Random random = new();
            DateTime temp = DateTime.Now;

            MemberEntity member = new() {
                Created = temp,
                CreatedBy = 1,
                Updated = temp,
                UpdatedBy = 1,
                Firstname = random.NextFirstname(),
                Lastname = random.NextLastname(),
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

            return member;
        }

        private static MusicianEntity CreateMusicianEntity() {
            Random random = new();
            DateTime temp = DateTime.Now;

            MusicianEntity musician = new() {
                Created = temp,
                CreatedBy = 1,
                Updated = temp,
                UpdatedBy = 1,
                Firstname = random.NextFirstname(),
                Lastname = random.NextLastname(),
                DateOfBirth = random.NextDateTime(new DateTime(1000, 1, 1), new DateTime(DateTime.Now.Year - 20, 12, 31)),
            };

            if (musician.DateOfBirth < DateTime.Now.AddYears(-100) || (musician.DateOfBirth <= DateTime.Now.AddYears(-50) && random.NextBoolean())) {
                DateTime latestDeath = new(musician.DateOfBirth.Value.Year + 100, 12, 31);
                musician.DateOfDeath = random.NextDateTime(new DateTime(musician.DateOfBirth.Value.Year + 40, 1, 1),
                  latestDeath > DateTime.Now ? DateTime.Now : latestDeath);
            }

            return musician;
        }

        private static MusicianEntity CreatePseudonym(MusicianEntity origin) {
            Random random = new();
            DateTime temp = DateTime.Now;

            return new() {
                Created = temp,
                CreatedBy = 1,
                Updated = temp,
                UpdatedBy = 1,
                Firstname = random.NextFirstname(),
                Lastname = random.NextLastname(),
                Origin = origin,
            };
        }

        private static UserEntity CreateUserEntity() {
            Random random = new();
            DateTime temp = DateTime.Now;

            return new UserEntity() {
                Created = temp,
                CreatedBy = 1,
                Updated = temp,
                UpdatedBy = 1,
                Firstname = random.NextFirstname(),
                Lastname = random.NextLastname(),
                DateOfBirth = random.NextDateTime(new DateTime(DateTime.Now.Year - 100, 1, 1), new DateTime(DateTime.Now.Year - 14, 12, 31)),
            };
        }
        #endregion CREATE SAMPLE ENTITIES
    }
}
