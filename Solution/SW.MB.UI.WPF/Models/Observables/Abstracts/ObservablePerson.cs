using System;
using SW.MB.Domain.Contracts.Models;

namespace SW.MB.UI.WPF.Models.Observables.Abstracts {
    public abstract class ObservablePerson : ObservableEntity {
        private string _Firstname;
        private string _Lastname;
        private DateOnly? _DateOfBirth;

        public string Firstname {
            get => _Firstname;
            set {
                if (SetProperty(ref _Firstname, value)) {
                    OnPropertyChanged(nameof(Fullname));
                }
            }
        }

        public string Lastname {
            get => _Lastname;
            set {
                if (SetProperty(ref _Lastname, value)) {
                    OnPropertyChanged(nameof(Fullname));
                }
            }
        }

        public DateOnly? DateOfBirth {
            get => _DateOfBirth;
            set => SetProperty(ref _DateOfBirth, value);
        }

        public string Fullname => $"{Firstname} {Lastname}";

        #region CONSTRUCTORS
        public ObservablePerson() {
            _Firstname = string.Empty;
            _Lastname = string.Empty;
        }

        public ObservablePerson(IPerson source) : base(source) {
            _Firstname = source.Firstname;
            _Lastname = source.Lastname;
            _DateOfBirth = source.DateOfBirth;
        }
        #endregion CONSTRUCTORS
    }
}
