using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables.Abstracts;

namespace SW.MB.UI.WPF.Models.Observables {
  public class ObservableUser: ObservablePerson {
    public string Mail { get; set; }

    #region CONSTRUCTORS
    public ObservableUser() : base() {
      Mail = string.Empty;
    }

    public ObservableUser(UserRecord record) : base(record) {
      Mail = record.Mail;
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
