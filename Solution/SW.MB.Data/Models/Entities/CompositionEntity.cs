using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
    [Table("Compositions")]
    public class CompositionEntity : Entity {
        public virtual ICollection<MandatorEntity> Mandators { get; set; } = new List<MandatorEntity>();

        public string Title { get; set; } = string.Empty;
    }
}
