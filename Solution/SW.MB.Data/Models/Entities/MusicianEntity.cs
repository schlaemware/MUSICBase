using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
    [Table("Musicians")]
    public class MusicianEntity : PersonEntity {
        public DateTime? DateOfDeath { get; set; }
    }
}
