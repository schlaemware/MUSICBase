using System;
using System.Collections.Generic;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables.Abstracts;

namespace SW.MB.UI.WPF.Models.Observables {
  public class ObservableMember: ObservablePerson {
    public List<int> YearsOfJoining { get; set; }
    public List<int> YearsOfSeparation { get; init; }

    #region CONSTRUCTORS
    public ObservableMember() : base() {
      YearsOfJoining = new List<int>();
      YearsOfSeparation = new List<int>();
    }

    public ObservableMember(MemberRecord record) : base(record) {
      YearsOfJoining = new List<int>(record.YearsOfJoining ?? Array.Empty<int>());
      YearsOfSeparation = new List<int>(record.YearsOfSeparation ?? Array.Empty<int>());
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
