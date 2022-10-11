using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  public class MemberEntity : PersonEntity {
    public string? YearsOfJoining { get; set; }
    public string? YearsOfSeparation { get; set; }
  }
}
