using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  public class CompositionEntity : Entity {
    public virtual ICollection<MandatorEntity>? Mandators { get; set; }

    public string Title { get; set; } = string.Empty;
  }
}
