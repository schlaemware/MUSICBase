using SW.MB.Domain.Models.Records.Abstracts;

namespace SW.MB.Domain.Models.Records {
    public record class CompositionRecord : EntityRecord {
        public string Title { get; init; } = string.Empty;
    }
}
