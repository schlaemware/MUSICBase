using System;
using Local.Framework.WPF;
using SW.MB.Data.Contracts;

namespace SW.MB.UI.WPF.Models.Observables.Abstracts {
  public abstract class ObservableEntity: ObservableObject, IEntity {
    public int ID { get; set; }

    public DateTime Created { get; set; }

    public int CreatedBy { get; set; }

    public DateTime Updated { get; set; }

    public int UpdatedBy { get; set; }
  }
}
