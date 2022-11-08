using SW.MB.Domain.Models.Records.Abstracts;

namespace SW.MB.Domain.Models.Records {
    public record class UserRecord : PersonRecord {
        public string? Mail { get; init; }
    }
}
