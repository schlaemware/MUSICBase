using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions {
  internal static class MemberRecordExtensions {
    public static MemberEntity ToEntity(this MemberRecord record) {
      return new MemberEntity() {
        ID = record.ID,
        Created = record.Created,
        CreatedBy = record.CreatedBy,
        Updated = record.Updated,
        UpdatedBy = record.UpdatedBy,
        Firstname = record.Firstname,
        Lastname = record.Lastname,
        DateOfBirth = record.DateOfBirth?.ToDateTime(TimeOnly.MinValue),
        YearsOfJoining = string.Join(';', record.YearsOfJoining ?? Array.Empty<int>()),
        YearsOfSeparation = string.Join(';', record.YearsOfSeparation ?? Array.Empty<int>()),
      };
    }
  }
}
