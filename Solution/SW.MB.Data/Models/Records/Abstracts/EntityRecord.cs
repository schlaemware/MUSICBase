using SW.MB.Data.Contracts;

namespace SW.MB.Data.Models.Records.Abstracts {
  public abstract record class EntityRecord : IEntity {
    public int ID { get; init; }
    public DateTime Created { get; init; } = DateTime.Now;
    public int CreatedBy { get; init; }
    public DateTime Updated { get; init; } = DateTime.Now;
    public int UpdatedBy { get; init; }
  }
}
