using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions {
    internal static class MemberEntityExtensions {
        public static MemberRecord ToRecord(this MemberEntity entity) {
            return new MemberRecord() {
                ID = entity.ID,
                Created = entity.Created,
                CreatedBy = entity.CreatedBy,
                Updated = entity.Updated,
                UpdatedBy = entity.UpdatedBy,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname,
                DateOfBirth = entity.DateOfBirth is DateTime date ? DateOnly.FromDateTime(date) : null,
                YearsOfJoining = entity.YearsOfJoining?.Split(';').Select(x => int.Parse(x)).ToArray(),
                YearsOfSeparation = entity.YearsOfSeparation?.Split(';').Select(x => int.Parse(x)).ToArray(),
            };
        }
    }
}
