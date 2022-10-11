using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions {
  internal static class MusicianEntityExtensions {
    public static MusicianRecord ToRecord(this MusicianEntity entity) {
      return new MusicianRecord() {
        ID = entity.ID,
        Created = entity.Created,
        CreatedBy = entity.CreatedBy,
        Updated = entity.Updated,
        UpdatedBy = entity.UpdatedBy,
        Firstname = entity.Firstname,
        Lastname = entity.Lastname,
        DateOfBirth = entity.DateOfBirth,
        DateOfDeath = entity.DateOfDeath,
      };
    }
  }
}
