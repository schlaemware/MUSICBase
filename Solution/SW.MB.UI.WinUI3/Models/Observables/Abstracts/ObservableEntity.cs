using System;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.Data.Contracts.Models;

namespace SW.MB.UI.WinUI3.Models.Observables.Abstracts {
  public class ObservableEntity : ObservableObject, IEntity {
    public int ID { get; set; }
    public DateTime Created { get; set; }
    public int CreatedBy { get; set; }
    public DateTime Updated { get; set; }
    public int UpdatedBy { get; set; }

    #region CONSTRUCTORS
    public ObservableEntity() { }

    public ObservableEntity(IEntity entity) {
      ID = entity.ID;
      Created = entity.Created;
      CreatedBy = entity.CreatedBy;
      Updated = entity.Updated;
      UpdatedBy = entity.UpdatedBy;
    }
    #endregion CONSTRUCTORS
  }
}
