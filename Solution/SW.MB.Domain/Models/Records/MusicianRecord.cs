using SW.MB.Domain.Models.Records.Abstracts;

namespace SW.MB.Domain.Models.Records {
    public record class MusicianRecord : PersonRecord {
        public DateOnly? DateOfDeath { get; init; }
    }
}
