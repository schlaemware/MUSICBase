using Microsoft.Extensions.DependencyInjection;
using SW.MB.Data.Contracts;
using SW.MB.Domain.Contracts;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Implementations.Abstracts;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Implementations {
  internal class DefaultCompositionsService: ServiceBase, ICompositionsService {
    #region CONSTRUCTORS
    public DefaultCompositionsService(IServiceProvider serviceProvider) : base(serviceProvider) {
      // empty...
    }
    #endregion CONSTRUCTORS

    public IEnumerable<CompositionRecord> GetAll() {
      IUnitOfWork uow = ServiceProvider.GetRequiredService<IUnitOfWork>();
      return uow.Compositions.Select(x => x.ToRecord());
    }

    public void Update(CompositionRecord record) {
      IUnitOfWork uow = ServiceProvider.GetRequiredService<IUnitOfWork>();
      SetAllProperties(uow.Compositions.SingleOrDefault(x => x.ID == record.ID), record.ToEntity());
      uow.SaveChanges();
    }

    public void UpdateRange(params CompositionRecord[] records) {
      IUnitOfWork uow = ServiceProvider.GetRequiredService<IUnitOfWork>();
      foreach (CompositionRecord record in records) {
        SetAllProperties(uow.Compositions.SingleOrDefault(x => x.ID == record.ID), record.ToEntity());
      }
      
      uow.SaveChanges();
    }
  }
}
