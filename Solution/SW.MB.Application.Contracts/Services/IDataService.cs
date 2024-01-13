using SW.MB.Application.Contracts.Records;

namespace SW.MB.Application.Contracts.Services {
    public interface IDataService<TRecord, TKey> : IServiceBase where TRecord : EntityRecord<TKey> where TKey : struct, IEquatable<TKey> {
        public Task<IEnumerable<TRecord>> GetRecordsAsync(CancellationToken cancellationToken = default);
    }
}
