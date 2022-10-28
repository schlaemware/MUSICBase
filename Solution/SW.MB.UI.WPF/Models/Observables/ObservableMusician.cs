using System;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables.Abstracts;

namespace SW.MB.UI.WPF.Models.Observables {
    public class ObservableMusician : ObservablePerson {
        private DateTime? _DateOfDeath;
        private ObservableMusician? _Origin;

        public DateTime? DateOfDeath {
            get => _DateOfDeath;
            set => SetProperty(ref _DateOfDeath, value);
        }

        public ObservableMusician? Origin {
            get => _Origin;
            private set => SetProperty(ref _Origin, value);
        }

        #region CONSTRUCTORS
        public ObservableMusician() : base() {
            // empty...
        }

        public ObservableMusician(MusicianRecord record) : base(record) {
            _DateOfDeath = record.DateOfDeath;

            if (record.Origin is MusicianRecord mRecord) {
                _Origin = new ObservableMusician(mRecord);
            }
        }
        #endregion CONSTRUCTORS

        public MusicianRecord ToRecord() {
            return new MusicianRecord() {
                ID = ID,
                Created = Created,
                CreatedBy = CreatedBy,
                Updated = Updated,
                UpdatedBy = UpdatedBy,
                Firstname = Firstname,
                Lastname = Lastname,
                DateOfBirth = DateOfBirth,
                DateOfDeath = DateOfDeath
            };
        }
    }
}
