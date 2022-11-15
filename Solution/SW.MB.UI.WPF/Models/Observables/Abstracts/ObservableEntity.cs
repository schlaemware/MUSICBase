using System;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.Data.Contracts.Models;

namespace SW.MB.UI.WPF.Models.Observables.Abstracts {
  public abstract class ObservableEntity: ObservableObject, IEntity {
    private bool _IsEditMode;

    public int ID { get; }

    public DateTime Created { get; }

    public int CreatedBy { get; }

    public DateTime Updated { get; }

    public int UpdatedBy { get; }

    public bool IsEditMode {
      get => _IsEditMode;
      set => SetProperty(ref _IsEditMode, value);
    }

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
