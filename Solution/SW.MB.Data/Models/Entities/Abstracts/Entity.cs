using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Contracts.Models;

namespace SW.MB.Data.Models.Entities.Abstracts {
  public abstract class Entity: IEntity {
    [Key]
    [Column(Order = 0)]
    public int ID { get; set; }

    [Column(Order = 1, TypeName = "timestamp")]
    public DateTime Created { get; set; }

    [Column(Order = 2)]
    public int CreatedBy { get; set; }

    [Column(Order = 3, TypeName = "timestamp")]
    public DateTime Updated { get; set; }

    [Column(Order = 4)]
    public int UpdatedBy { get; set; }
  }
}
