using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  [Table("Members")]
  public class MemberEntity: PersonEntity {
    [Column(Order = 9)]
    public MandatorEntity Mandator { get; set; }

    [Column(Order = 10, TypeName = "varchar(50)")]
    public string YearsOfJoining { get; set; }

    [Column(Order = 11, TypeName = "varchar(50)")]
    public string? YearsOfSeparation { get; set; }
  }
}
