using SW.MB.Data.Contracts;

namespace SW.MB.Data.Models.Entities.Abstracts {
  internal abstract class Entity: IEntity {
    public int ID { get; set; }
    public DateTime Created { get; set; }
    public int CreatedBy { get; set; }
    public DateTime Updated { get; set; }
    public int UpdatedBy { get; set; }
  }
}
