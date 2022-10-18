using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables.Abstracts;

namespace SW.MB.UI.WPF.Models.Observables {
    public class ObservableMandator : ObservableEntity {
        private string _Name;

        public string Name {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

    #region CONSTRUCTORS
    public ObservableMandator() : base() {
      _Name = string.Empty;
    }

    public ObservableMandator(MandatorRecord record) : base(record) {
            _Name = record.Name;
        }
        #endregion CONSTRUCTORS

        public MandatorRecord ToRecord() {
            return new MandatorRecord() {
                ID = ID,
                Created = Created,
                CreatedBy = CreatedBy,
                Updated = Updated,
                UpdatedBy = UpdatedBy,
                Name = Name
            };
        }
    }
}
