using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
    [Table("Mandators")]
    public class MandatorEntity : Entity {
        public virtual ICollection<CompositionEntity>? Compositions { get; set; }
        public virtual ICollection<MemberEntity>? Members { get; set; }
        public virtual ICollection<MusicianEntity>? Musicians { get; set; }
        public virtual ICollection<UserEntity>? Users { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
