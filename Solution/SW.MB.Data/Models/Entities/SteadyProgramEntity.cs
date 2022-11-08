using SW.MB.Data.Contracts.Models;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  public class SteadyProgramEntity : ProgramEntity, IProgram {
    public DateTime DateOfRelease { get; set; }

    #region IPROGRAM
    DateTime IProgram.Date => DateOfRelease;
    #endregion IPROGRAM
  }
}
