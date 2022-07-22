using System.ComponentModel.DataAnnotations;

namespace SW.MB.DA.Models.Records {
  public record class CompositionRecord : EntityRecord {
    [Required]
    public string? Title { get; init; }
  }
}
