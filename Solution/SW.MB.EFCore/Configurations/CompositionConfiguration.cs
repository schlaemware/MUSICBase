using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SW.MB.Domain.Entities;

namespace SW.MB.EFCore.Configurations {
    internal class CompositionConfiguration : IEntityTypeConfiguration<Composition> {
        public void Configure(EntityTypeBuilder<Composition> builder) {
            builder.ToTable($"{nameof(Composition)}s");

            builder.Property(x => x.CreatedBy).HasMaxLength(10);
            builder.Property(x => x.UpdatedBy).HasMaxLength(10);

            DataSeeding(builder);
        }

        [Conditional("DEBUG")]
        private static void DataSeeding(EntityTypeBuilder<Composition> builder) {
            for (int n = 1; n < 100; n++) {
                builder.HasData(new Composition() { 
                    ID = n,
                    Created = DateTime.Today,
                    CreatedBy = "DEBUG",
                    Updated = DateTime.Now,
                    UpdatedBy = "DEBUG",
                    Title = $"Komposition #{n}"
                });
            }
        }
    }
}
