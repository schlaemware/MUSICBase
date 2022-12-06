using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  [Table("Users")]
  public class UserEntity: PersonEntity {
    public virtual ICollection<MandatorEntity> Mandators { get; set; } = new List<MandatorEntity>();

    public string? Mail { get; set; }
    public string? PasswordHash { get; set; }
    public string? Username { get; set; }
  }
}
