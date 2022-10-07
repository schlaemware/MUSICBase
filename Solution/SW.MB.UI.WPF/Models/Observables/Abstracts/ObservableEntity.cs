using System;
using SW.Framework.WPF;
using SW.MB.Data.Contracts;

namespace SW.MB.UI.WPF.Models.Observables.Abstracts {
  public abstract class ObservableEntity: ObservableObject, IEntity {
    public int ID { get; }

    public DateTime Created { get; }

    public int CreatedBy { get; }

    public DateTime Updated { get; }

    public int UpdatedBy { get; }

    #region CONSTRUCTORS
    public ObservableEntity() {
      Created = DateTime.Now;
      Updated = DateTime.Now;
    }

    public ObservableEntity(IEntity source) {
      ID = source.ID;
      Created = source.Created;
      CreatedBy = source.CreatedBy;
      Updated = source.Updated;
      UpdatedBy = source.UpdatedBy;
    }
    #endregion CONSTRUCTORS
  }
}
