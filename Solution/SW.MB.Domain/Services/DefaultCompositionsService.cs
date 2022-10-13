using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
  internal class DefaultCompositionsService: ServiceBase, ICompositionsService {
    private readonly IUnitOfWork _UnitOfWork;

    #region CONSTRUCTORS
    public DefaultCompositionsService(IUnitOfWork uow) : base() {
      _UnitOfWork = uow;
    }
    #endregion CONSTRUCTORS

    public IEnumerable<CompositionRecord> GetAll() {
      return _UnitOfWork.Compositions.Select(x => x.ToRecord());
    }

    public void Update(CompositionRecord record) {
      SetAllProperties(_UnitOfWork.Compositions.SingleOrDefault(x => x.ID == record.ID), record.ToEntity());
      _UnitOfWork.SaveChanges();
    }

    public void UpdateRange(params CompositionRecord[] records) {
      foreach (CompositionRecord record in records) {
        if (_UnitOfWork.Compositions.SingleOrDefault(x => x.ID == record.ID) is CompositionEntity entity) {
          SetAllProperties(entity, record.ToEntity());
        } else {
          _UnitOfWork.Compositions.Add(record.ToEntity());
        }
      }

      _UnitOfWork.SaveChangesAsync();
    }
  }
}
