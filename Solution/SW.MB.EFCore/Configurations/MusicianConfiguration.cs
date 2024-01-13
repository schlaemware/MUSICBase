using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SW.MB.Domain.Entities;

namespace SW.MB.EFCore.Configurations {
    internal class MusicianConfiguration : IEntityTypeConfiguration<Musician> {
        public void Configure(EntityTypeBuilder<Musician> builder) {
            builder.ToTable($"{nameof(Musician)}s");

            builder.Property(x => x.CreatedBy).HasMaxLength(10);
            builder.Property(x => x.UpdatedBy).HasMaxLength(10);

            DataSeeding(builder);
        }

        [Conditional("DEBUG")]
        private static void DataSeeding(EntityTypeBuilder<Musician> builder) {
            for (int n = 1; n < 100; n++) {
                builder.HasData(new Musician() {
                    ID = n,
                    Created = DateTime.Today,
                    CreatedBy = "DEBUG",
                    Updated = DateTime.Now,
                    UpdatedBy = "DEBUG",
                    Firstname = "Hans",
                    Lastname = "Zimmer",
                    DateOfBirth = new DateOnly(1900 + n, (n % 12) + 1, (n % 28) + 1)
                });
            }
        }
    }
}
