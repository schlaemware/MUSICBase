using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  [Table("Musicians")]
  public class MusicianEntity: PersonEntity {
    public virtual ICollection<BandEntity> Bands { get; set; } = new List<BandEntity>();

    public DateTime? DateOfDeath { get; set; }
    public MusicianEntity? Origin { get; set; }
  }
}
