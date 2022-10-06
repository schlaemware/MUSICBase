using SW.MB.Data.Models.Records.Abstracts;

namespace SW.MB.Data.Models.Records {
  public record class CompositionRecord : EntityRecord {
    public string? Title { get; init; }
  }
}
