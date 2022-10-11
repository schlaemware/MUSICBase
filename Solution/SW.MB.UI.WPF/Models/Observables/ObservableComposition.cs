using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables.Abstracts;

namespace SW.MB.UI.WPF.Models.Observables {
  public class ObservableComposition : ObservableEntity {
    private string _Title;

    public string Title {
      get => _Title;
      set => SetProperty(ref _Title, value);
    }

    #region CONSTRUCTORS
    public ObservableComposition() : base() {
      _Title = string.Empty;
    }

    public ObservableComposition(CompositionRecord record) : base(record) {
      _Title = record.Title;
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
