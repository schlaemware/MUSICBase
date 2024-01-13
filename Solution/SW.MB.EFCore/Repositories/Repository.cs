using Microsoft.EntityFrameworkCore;
using SW.MB.Domain.Entities;
using SW.MB.Domain.Repositories;
using SW.MB.EFCore.EFCore;

namespace SW.MB.EFCore.Repositories {
    public class Repository<TEntity, TKey>(MUSICBaseDbContext context) : IRepository<TEntity, TKey> where TEntity : Entity<TKey> where TKey : struct, IEquatable<TKey> {
        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) 
            => await context.Set<TEntity>().ToArrayAsync();
    }
}
