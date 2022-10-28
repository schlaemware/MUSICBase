using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
    [Table("Bands")]
    public class BandEntity : Entity {
        public virtual ICollection<MandatorEntity> Mandators { get; set; } = new List<MandatorEntity>();

        public string? Name { get; set; }

        public virtual ICollection<MusicianEntity> Musicians { get; set; } = new List<MusicianEntity>();
    }
}
