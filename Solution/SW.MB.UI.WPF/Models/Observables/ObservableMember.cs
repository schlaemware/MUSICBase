using System;
using System.Collections.ObjectModel;
using System.Linq;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables.Abstracts;

namespace SW.MB.UI.WPF.Models.Observables {
  public class ObservableMember: ObservablePerson {
    public ObservableCollection<int> YearsOfJoining { get; }
    public ObservableCollection<int> YearsOfSeparation { get; }

    public string YearsOfJoiningString => string.Join(" & ", YearsOfJoining);
    public string YearsOfSeparationString => string.Join(" & ", YearsOfSeparation);

    #region CONSTRUCTORS
    public ObservableMember() : base() {
      YearsOfJoining = new();
      YearsOfSeparation = new();
    }

    public ObservableMember(MemberRecord record) : base(record) {
      YearsOfJoining = new ObservableCollection<int>(record.YearsOfJoining ?? Array.Empty<int>());
      YearsOfSeparation = new ObservableCollection<int>(record.YearsOfSeparation ?? Array.Empty<int>());

      YearsOfJoining.Add(2000);
      YearsOfJoining.Add(2020);
      YearsOfSeparation.Add(2018);
    }
    #endregion CONSTRUCTORS

    public MemberRecord ToRecord() {
      return new MemberRecord() {
        ID = ID,
        Created = Created,
        CreatedBy = CreatedBy,
        Updated = Updated,
        UpdatedBy = UpdatedBy,
        Firstname = Firstname,
        Lastname = Lastname,
        DateOfBirth = DateOfBirth,
        YearsOfJoining = YearsOfJoining.ToArray(),
        YearsOfSeparation = YearsOfSeparation.ToArray(),
      };
    }
  }
}
