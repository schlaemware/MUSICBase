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
        YearsOfJoining = ExtractYears(entity.YearsOfJoining),
        YearsOfSeparation = ExtractYears(entity.YearsOfSeparation),
      };
    }

    private static int[] ExtractYears(string? str) {
      List<int> years = new();
      if (!string.IsNullOrEmpty(str)) {
        IEnumerable<string> parts = str.Split(MemberRecordExtensions.JOIN_CHAR, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());
        foreach (string part in parts) {
          if (int.TryParse(part, out int year)) {
            years.Add(year);
          }
        }
      }

      return years.ToArray();
    }
  }
}
