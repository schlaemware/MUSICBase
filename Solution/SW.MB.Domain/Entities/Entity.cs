using SW.MB.Domain.Shared.Interfaces;

namespace SW.MB.Domain.Entities {
    public abstract class Entity<TKey> : IEntity<TKey> where TKey : struct, IEquatable<TKey> {
        public TKey ID { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; }
    }
}
