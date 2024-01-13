using SW.MB.Domain.Shared.Interfaces;

namespace SW.MB.Domain.Repositories {
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey> where TKey : struct, IEquatable<TKey> {
        public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
