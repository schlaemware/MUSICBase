using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  [Table("Users")]
  public class UserEntity: PersonEntity {
    public virtual ICollection<MandatorEntity> Mandators { get; set; } = new List<MandatorEntity>();

    [Column(Order = 11, TypeName = "varchar(50)")]
    public string? Mail { get; set; }

    [Column(Order = 10, TypeName = "varchar(100)")]
    public string? PasswordHash { get; set; }

    [Column(Order = 9, TypeName = "varchar(50)")]
    public string? Username { get; set; }
  }
}
