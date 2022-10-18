using SW.MB.Domain.Models.Records.Abstracts;

namespace SW.MB.Domain.Models.Records {
    public record class MusicianRecord : PersonRecord {
        public DateTime? DateOfDeath { get; init; }
    }
}
