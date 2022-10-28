using System;
using System.Collections.ObjectModel;
using System.Linq;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables.Abstracts;

namespace SW.MB.UI.WPF.Models.Observables {
    public class ObservableBand : ObservableEntity {
        private string _Name;

        public string Name {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        public ObservableCollection<ObservableMusician> Musicians { get; }

        #region CONSTRUCTORS
        public ObservableBand() {
            _Name = string.Empty;
            Musicians = new ObservableCollection<ObservableMusician>();
        }

        public ObservableBand(BandRecord source) : base(source) {
            _Name = source.Name;
            Musicians = new ObservableCollection<ObservableMusician>(source.Musicians?.Select(x => new ObservableMusician(x)) ?? Array.Empty<ObservableMusician>());
        }
        #endregion CONSTRUCTORS
    }
}
