namespace SW.MB.Domain.Shared.Interfaces {
    public interface IEntity<TKey> where TKey : struct, IEquatable<TKey> {
        public TKey ID { get; }

        public DateTime Created { get; }

        public string CreatedBy { get; }

        public DateTime Updated { get; }

        public string UpdatedBy { get; }
    }
}
