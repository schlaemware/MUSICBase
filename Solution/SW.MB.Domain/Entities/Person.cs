using SW.MB.Domain.Shared.Interfaces;

namespace SW.MB.Domain.Entities {
    public abstract class Person<TKey> : Entity<TKey>, IPerson<TKey> where TKey : struct, IEquatable<TKey> {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateOnly? DateOfBirth { get; set; }
    }
}
