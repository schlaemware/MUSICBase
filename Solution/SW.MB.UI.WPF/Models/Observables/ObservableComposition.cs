using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables.Abstracts;

namespace SW.MB.UI.WPF.Models.Observables {
  public class ObservableComposition : ObservableEntity {
    public string? Title { get; set; }

    #region CONSTRUCTORS
    public ObservableComposition() : base() {
      Title = string.Empty;
    }

    public ObservableComposition(CompositionRecord record) : base(record) {
      Title = record.Title;
    }
    #endregion CONSTRUCTORS

    public CompositionRecord ToRecord() {
      return new CompositionRecord() {
        ID = ID,
        Created = Created,
        CreatedBy = CreatedBy,
        Updated = Updated,
        UpdatedBy = UpdatedBy,
        Title = Title
      };
    }
  }
}
