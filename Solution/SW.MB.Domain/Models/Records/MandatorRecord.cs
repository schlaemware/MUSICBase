using SW.MB.Domain.Models.Records.Abstracts;

namespace SW.MB.Domain.Models.Records {
    public record class MandatorRecord : EntityRecord {
        public string Name { get; init; } = string.Empty;
    }
}
