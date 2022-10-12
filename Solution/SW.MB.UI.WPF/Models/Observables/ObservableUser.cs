using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables.Abstracts;

namespace SW.MB.UI.WPF.Models.Observables {
    public class ObservableUser : ObservablePerson {
        private string _Mail;

        public string Mail {
            get => _Mail;
            set => SetProperty(ref _Mail, value);
        }

        #region CONSTRUCTORS
        public ObservableUser() : base() {
            _Mail = string.Empty;
        }

        public ObservableUser(UserRecord record) : base(record) {
            _Mail = record.Mail;
        }
        #endregion CONSTRUCTORS

        public UserRecord ToRecord() {
            return new UserRecord() {
                ID = ID,
                Created = Created,
                CreatedBy = CreatedBy,
                Updated = Updated,
                UpdatedBy = UpdatedBy,
                Firstname = Firstname,
                Lastname = Lastname,
                DateOfBirth = DateOfBirth,
                Mail = Mail,
            };
        }
    }
}
