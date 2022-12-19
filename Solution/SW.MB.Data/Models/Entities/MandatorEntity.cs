using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  [Table("Mandators")]
  public class MandatorEntity: Entity {
    public virtual ICollection<CompositionEntity> Compositions { get; set; } = new List<CompositionEntity>();
    public virtual ICollection<FormationEntity> Formations { get; set; } = new List<FormationEntity>();
    public virtual ICollection<MemberEntity> Members { get; set; } = new List<MemberEntity>();
    public virtual ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();

    [Column(Order = 5, TypeName = "varchar(50)")]
    public string Name { get; set; }
  }
}
