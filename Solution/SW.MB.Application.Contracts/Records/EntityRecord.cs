using SW.MB.Domain.Shared.Interfaces;

namespace SW.MB.Application.Contracts.Records {
    public abstract record class EntityRecord<TKey> : IEntity<TKey> where TKey : struct, IEquatable<TKey> {
        public TKey ID { get; init; }

        public DateTime Created { get; init; }

        public string CreatedBy { get; init; }

        public DateTime Updated { get; init; }

        public string UpdatedBy { get; init; }
    }
}
