using System;
using SW.MB.Domain.Contracts.Models;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Models.Enumerations;

namespace SW.MB.UI.WinUI3.Models.Observables.Abstracts {
  public abstract class ObservablePerson: ObservableEntity, IComparable<ObservablePerson> {
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public string Fullname => App.GetService<IDisplaySettingsService>().PersonsDisplayMode switch {
      PersonsDisplayMode.LastnameFirstname => $"{Lastname}, {Firstname}",
      _ => $"{Firstname} {Lastname}"
    };

    #region CONSTRUCTORS
    public ObservablePerson() {
      Firstname = string.Empty;
      Lastname = string.Empty;
    }

    public ObservablePerson(IPerson person) : base(person) {
      Firstname = person.Firstname;
      Lastname = person.Lastname;
      DateOfBirth = person.DateOfBirth;
    }
    #endregion CONSTRUCTORS

    public int CompareTo(ObservablePerson? other) {
      if (other == null) {
        return 1;
      }

      switch (App.GetService<IDisplaySettingsService>().PersonsOrderingMode) {
        case PersonsOrderingMode.FirstnameLastnameBirthdate: {
            if (string.Compare(Firstname, other.Firstname) == 0) {
              if (string.Compare(Lastname, other.Lastname) == 0) {
                return DateTime.Compare(DateOfBirth ?? default, other.DateOfBirth ?? default);
              } else {
                return string.Compare(Lastname, other.Lastname);
              }
            } else {
              return string.Compare(Firstname, other.Firstname);
            }
          }

        default: {
            if (string.Compare(Lastname, other.Lastname) == 0) {
              if (string.Compare(Firstname, other.Firstname) == 0) {
                return DateTime.Compare(DateOfBirth ?? default, other.DateOfBirth ?? default);
              } else {
                return string.Compare(Firstname, other.Firstname);
              }
            } else {
              return string.Compare(Lastname, other.Lastname);
            }
          }
      }
    }
  }
}
