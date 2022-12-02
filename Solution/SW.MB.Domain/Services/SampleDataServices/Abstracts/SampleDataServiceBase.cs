using SW.MB.Data.Contracts.Models;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services.SampleDataServices.Abstracts {
  internal abstract class SampleDataServiceBase<T> : DataServiceBase where T : IEntity {
    protected static readonly Dictionary<int, T> _RecordsDictionary = new();

    #region CONSTRUCTORS
    public SampleDataServiceBase() {
      if (!_RecordsDictionary.Any()) {
        CreateSampleData();
      }
    }
    #endregion CONSTRUCTORS

    public IEnumerable<T> GetAll() {
      return _RecordsDictionary.Values;
    }

    public IEnumerable<T> GetAll(params MandatorRecord?[]? mandators) {
      return _RecordsDictionary.Values;
    }

    public void UpdateRange(params T[] records) {
      foreach (T record in records) {
        _RecordsDictionary.Remove(record.ID);
        _RecordsDictionary.Add(record.ID, record);
      }
    }

    protected abstract void CreateSampleData();
  }
}
