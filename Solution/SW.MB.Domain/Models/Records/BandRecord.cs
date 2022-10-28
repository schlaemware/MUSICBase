using SW.MB.Domain.Models.Records.Abstracts;

namespace SW.MB.Domain.Models.Records {
    public record class BandRecord: EntityRecord {
        public string Name { get; init; } = string.Empty;
        public MusicianRecord[]? Musicians { get; init; }
    }
}
