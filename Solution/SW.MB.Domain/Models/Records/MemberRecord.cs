using SW.MB.Domain.Models.Records.Abstracts;

namespace SW.MB.Domain.Models.Records {
    public record class MemberRecord : PersonRecord {
        public int[]? YearsOfJoining { get; init; }
        public int[]? YearsOfSeparation { get; init; }
    }
}
