using System.ComponentModel.DataAnnotations.Schema;
using SW.MB.Data.Contracts.Models;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Entities {
    [Table("RepertoirePrograms")]
    public class RepertoireProgramEntity : ProgramEntity, IProgram {
        [Column(Order = 7, TypeName = "date")]
        public DateTime DateOfRelease { get; set; }

        #region IPROGRAM
        DateTime IProgram.Date => DateOfRelease;
        #endregion IPROGRAM
    }
}
