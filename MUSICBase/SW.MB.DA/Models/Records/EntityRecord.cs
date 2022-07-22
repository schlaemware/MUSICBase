using System.ComponentModel.DataAnnotations;

namespace SW.MB.DA.Models.Records {
    public abstract record class EntityRecord {
        [Key]
        public int ID { get; internal init; }

        [Required]
        public DateTime Created { get; internal init; }

        [Required]
        public int CreatedBy { get; init; }

        [Required]
        public DateTime Updated { get; internal init; }

        [Required]
        public int UpdatedBy { get; init; }

        public override string ToString() {
            return $"#{ID}";
        }
    }
}
