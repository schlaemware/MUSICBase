using SW.MB.Data.Contracts.Models;

namespace SW.MB.Data.Models.Entities.Abstracts
{
    public abstract class PersonEntity: Entity, IPerson {
    public virtual ICollection<MandatorEntity>? Mandators { get; set; }

    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
  }
}
