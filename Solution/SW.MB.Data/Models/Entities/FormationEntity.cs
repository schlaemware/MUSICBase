using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  [Table("Formations")]
  public class FormationEntity : Entity {
    public MandatorEntity Mandator { get; set; }
    public string Name { get; set; }
  }
}
