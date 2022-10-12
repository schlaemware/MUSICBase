using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions {
    internal static class UserRecordExtensions {
        public static UserEntity ToEntity(this UserRecord record) {
            return new UserEntity() {
                ID = record.ID,
                Created = record.Created,
                CreatedBy = record.CreatedBy,
                Updated = record.Updated,
                UpdatedBy = record.UpdatedBy,
                Firstname = record.Firstname,
                Lastname = record.Lastname,
                DateOfBirth = record.DateOfBirth?.ToDateTime(TimeOnly.MinValue),
                Mail = record.Mail,
            };
        }
    }
}
