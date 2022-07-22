using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SW.MB.DA.Models.Records {
    [Table("Compositions")]
    public record class CompositionRecord : EntityRecord {
        [Required]
        public string? Title { get; init; }

        public override string ToString() {
            return $"{Title} (#{ID})";
        }
    }
}
