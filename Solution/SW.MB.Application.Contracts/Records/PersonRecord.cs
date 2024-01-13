using SW.MB.Domain.Shared.Interfaces;

namespace SW.MB.Application.Contracts.Records {
    public abstract record class PersonRecord<TKey> : EntityRecord<TKey>, IPerson<TKey> where TKey : struct, IEquatable<TKey> {
        public string Firstname { get; init; }

        public string Lastname { get; init; }

        public DateOnly? DateOfBirth { get; init; }
    }
}
