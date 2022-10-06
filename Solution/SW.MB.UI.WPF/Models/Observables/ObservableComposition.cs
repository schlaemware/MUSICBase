using SW.MB.Data.Models.Records;

namespace SW.MB.UI.WPF.Models.Observables {
  internal class ObservableComposition {
    public string? Title { get; set; }

    #region CONSTRUCTORS
    public ObservableComposition() {
      // empty...
    }

    public ObservableComposition(CompositionRecord record) {
      Title = record.Title;
    }
    #endregion CONSTRUCTORS
  }
}
