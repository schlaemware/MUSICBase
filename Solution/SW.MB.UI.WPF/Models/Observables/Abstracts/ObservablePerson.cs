using System;
using SW.MB.Data.Contracts.Models;

namespace SW.MB.UI.WPF.Models.Observables.Abstracts
{
    public abstract class ObservablePerson: ObservableEntity {
    public string Firstname { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string Fullname => $"{Firstname} {Lastname}";

    #region CONSTRUCTORS
    public ObservablePerson() {
      Firstname = string.Empty;
      Lastname = string.Empty;
    }

    public ObservablePerson(IPerson source) : base(source) {
      Firstname = source.Firstname;
      Lastname = source.Lastname;
      DateOfBirth = source.DateOfBirth;
    }
    #endregion CONSTRUCTORS
  }
}
