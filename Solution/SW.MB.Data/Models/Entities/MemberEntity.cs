using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  [Table("Members")]
  public class MemberEntity: PersonEntity {
    public MandatorEntity Mandator { get; set; }
    public string? YearsOfJoining { get; set; }
    public string? YearsOfSeparation { get; set; }
  }
}
