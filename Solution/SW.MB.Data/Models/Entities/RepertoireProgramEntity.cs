using SW.MB.Data.Contracts.Models;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  public class RepertoireProgramEntity : ProgramEntity, IProgram {
    public DateTime DateOfRelease { get; set; }

    #region IPROGRAM
    DateTime IProgram.Date => DateOfRelease;
    #endregion IPROGRAM
  }
}
