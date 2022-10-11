using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  public class UserEntity : PersonEntity {
    public string Mail { get; set; } = string.Empty;
  }
}
