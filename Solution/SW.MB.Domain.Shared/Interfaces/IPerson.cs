namespace SW.MB.Domain.Shared.Interfaces {
    public interface IPerson<TKey> : IEntity<TKey> where TKey : struct, IEquatable<TKey> {
        public string Firstname { get; }

        public string Lastname { get; }

        public DateOnly? DateOfBirth { get; }
    }
}
