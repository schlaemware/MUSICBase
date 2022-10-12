using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
    [Table("Users")]
    public class UserEntity : PersonEntity {
        public string Mail { get; set; } = string.Empty;
    }
}
