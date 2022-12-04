using System.Collections.Generic;
using System.Linq;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.UI.WinUI3.Extensions;
using SW.MB.UI.WinUI3.Models.Observables;
using SW.MB.UI.WinUI3.ViewModels.Abstracts;

namespace SW.MB.UI.WinUI3.ViewModels {
    public class MusiciansViewModel: EntityMasterDetailViewModel<ObservableMusician> {
    protected override string DeleteDialogContent { get; } = "MusiciansViewModel_DeleteDialogContent".GetLocalizedString();
    protected override string DeleteDialogTitle { get; } = "MusiciansViewModel_DeleteDialogTitle".GetLocalizedString();

    #region CONSTRUCTORS
    public MusiciansViewModel() : base() { }
    #endregion CONSTRUCTORS

    protected override void LoadData() {
      IEnumerable<ObservableMusician> musicians = App.GetService<IMusiciansDataService>().GetAll().Select(x => new ObservableMusician(x));
      App.Dispatcher.TryEnqueue(() => musicians.ForEach(x => EntitiesCollection.Add(x)));
    }

    protected override void Save() {
      if (!IsEditMode && Selected != null) { 
        // Invert "IsEditMode" because of timing. IsEditMode is set before execution of this function.
        IMusiciansDataService musiciansService = App.GetService<IMusiciansDataService>();
        musiciansService.UpdateRange(Selected.ToRecord());
      }
    }
  }
}
