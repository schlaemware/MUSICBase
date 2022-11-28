using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Models.Observables.Abstracts;

namespace SW.MB.UI.WinUI3.Models.Observables {
    public class ObservableMusician : ObservablePerson {
        #region CONSTRUCTORS
        public ObservableMusician() { }

        public ObservableMusician(MusicianRecord record) : base(record) { }
        #endregion CONSTRUCTORS
    }
}
