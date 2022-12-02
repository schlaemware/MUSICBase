using System;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Models.Observables.Abstracts;

namespace SW.MB.UI.WinUI3.Models.Observables {
  public class ObservableComposition: ObservableEntity, IComparable<ObservableComposition> {
    public string Title { get; set; }

    #region CONSTRUCTORS
    public ObservableComposition() {
      Title = string.Empty;
    }

    public ObservableComposition(CompositionRecord record) : base(record) {
      Title = record.Title;
    }
    #endregion CONSTRUCTORS

    public int CompareTo(ObservableComposition? other) {
      if (other == null) {
        return 1;
      }

      return string.Compare(Title, other.Title);
    }

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
