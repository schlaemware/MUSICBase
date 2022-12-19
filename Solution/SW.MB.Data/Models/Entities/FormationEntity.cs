using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  [Table("Formations")]
  public class FormationEntity : Entity {
    [Column(Order = 5)]
    public MandatorEntity Mandator { get; set; }

    [Column(Order = 6, TypeName = "varchar(50)")]
    public string Name { get; set; }
  }
}
