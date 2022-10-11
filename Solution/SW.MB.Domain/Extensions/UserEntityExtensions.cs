using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions {
  internal static class UserEntityExtensions {
    public static UserRecord ToRecord(this UserEntity entity) {
      return new UserRecord() {
        ID = entity.ID,
        Created = entity.Created,
        CreatedBy = entity.CreatedBy,
        Updated = entity.Updated,
        UpdatedBy = entity.UpdatedBy,
        Firstname = entity.Firstname,
        Lastname = entity.Lastname,
        DateOfBirth = entity.DateOfBirth is DateTime birthDate ? DateOnly.FromDateTime(birthDate) : null,
        Mail = entity.Mail,
      };
    }
  }
}
