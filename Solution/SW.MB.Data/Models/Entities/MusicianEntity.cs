using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  [Table("Musicians")]
  public class MusicianEntity: PersonEntity {
    public virtual ICollection<BandEntity> Bands { get; set; } = new List<BandEntity>();

    [Column(Order = 9, TypeName = "date")]
    public DateTime? DateOfDeath { get; set; }

    [Column(Order = 10)]
    public MusicianEntity? Origin { get; set; }
  }
}
