using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions {
  internal static class MusicianRecordExtensions {
    public static MusicianEntity ToEntity(this MusicianRecord record) {
      return new MusicianEntity() {
        ID = record.ID,
        Created = record.Created,
        CreatedBy = record.CreatedBy,
        Updated = record.Updated,
        UpdatedBy = record.UpdatedBy,
        Firstname = record.Firstname,
        Lastname = record.Lastname,
        DateOfBirth = record.DateOfBirth?.ToDateTime(TimeOnly.MinValue),
        DateOfDeath = record.DateOfDeath?.ToDateTime(TimeOnly.MinValue),
      };
    }
  }
}
