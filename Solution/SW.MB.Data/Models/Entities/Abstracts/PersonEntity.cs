using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Contracts.Models;

namespace SW.MB.Data.Models.Entities.Abstracts {
  public abstract class PersonEntity: Entity, IPerson {
    [Column(Order = 5, TypeName = "varchar(50)")]
    public string Firstname { get; set; } = string.Empty;

    [Column(Order = 6, TypeName = "varchar(50)")]
    public string? Middlename { get; set; }

    [Column(Order = 7, TypeName = "varchar(50)")]
    public string Lastname { get; set; } = string.Empty;

    [Column(Order = 8, TypeName = "date")]
    public DateTime? DateOfBirth { get; set; }
  }
}
