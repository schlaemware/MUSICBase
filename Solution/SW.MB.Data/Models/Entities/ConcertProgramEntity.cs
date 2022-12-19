using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Contracts.Models;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
  [Table("ConcertPrograms")]
  public class ConcertProgramEntity: ProgramEntity, IProgram {
    [Column(Order = 6, TypeName = "date")]
    public DateTime ShowDate { get; set; }

    #region IPROGRAM
    DateTime IProgram.Date => ShowDate;
    #endregion IPROGRAM
  }
}
