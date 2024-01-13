using AutoMapper;
using SW.MB.Application.Contracts.Records;
using SW.MB.Application.Contracts.Services;
using SW.MB.Domain.Entities;
using SW.MB.Domain.Repositories;

namespace SW.MB.Application.WPF.Services {
    public class DataService<TRecord, TEntity, TKey>(IMapper mapper, IRepository<TEntity, TKey> repository) 
        : ServiceBase(), IDataService<TRecord, TKey> where TRecord : EntityRecord<TKey> where TEntity : Entity<TKey> where TKey : struct, IEquatable<TKey> 
    {
        public async Task<IEnumerable<TRecord>> GetRecordsAsync(CancellationToken cancellationToken = default) 
            => (await repository.GetAllAsync(cancellationToken)).Select(mapper.Map<TRecord>);
    }
}
