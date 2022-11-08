using SW.MB.Data.Contracts.Models;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  public class ConcertProgramEntity: ProgramEntity, IProgram {
    public DateTime ShowDate { get; set; }

    #region IPROGRAM
    DateTime IProgram.Date => ShowDate;
    #endregion IPROGRAM
  }
}
