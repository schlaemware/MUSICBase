using System.Collections.Generic;
using System.Linq;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.UI.WinUI3.Extensions;
using SW.MB.UI.WinUI3.Models.Observables;
using SW.MB.UI.WinUI3.ViewModels.Abstracts;

namespace SW.MB.UI.WinUI3.ViewModels {
    public class MandatorsViewModel: EntityMasterDetailViewModel<ObservableMandator> {
    protected override string DeleteDialogContent { get; } = "MandatorsViewModel_DeleteDialogContent".GetLocalizedString();
    protected override string DeleteDialogTitle { get; } = "MandatorsViewModel_DeleteDialogTitle".GetLocalizedString();

    #region CONSTRUCTORS
    public MandatorsViewModel() : base() { }
    #endregion CONSTRUCTORS

    protected override void LoadData() {
      IEnumerable<ObservableMandator> mandators = App.GetService<IMandatorsDataService>().GetAll().Select(x => new ObservableMandator(x)).OrderBy(x => x.Name);
      App.Dispatcher.TryEnqueue(() => mandators.ForEach(x => EntitiesCollection.Add(x)));
    }

    protected override void Save() {
      throw new System.NotImplementedException();
    }
  }
}
