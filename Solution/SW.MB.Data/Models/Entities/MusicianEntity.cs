using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  public class MusicianEntity : PersonEntity {
    public DateTime? DateOfDeath { get; set; }
  }
}
