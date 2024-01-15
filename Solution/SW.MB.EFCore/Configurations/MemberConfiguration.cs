using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SW.MB.Domain.Entities;

namespace SW.MB.EFCore.Configurations
{
    internal class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable($"{nameof(Member)}s");

            builder.Property(x => x.CreatedBy).HasMaxLength(10);
            builder.Property(x => x.UpdatedBy).HasMaxLength(10);

            DataSeeding(builder);
        }

        [Conditional("DEBUG")]
        private static void DataSeeding(EntityTypeBuilder<Member> builder)
        {
            for (int n = 1; n < 50; n++)
            {
                builder.HasData(new Member()
                {
                    ID = n,
                    Created = DateTime.Today,
                    CreatedBy = "DEBUG",
                    Updated = DateTime.Now,
                    UpdatedBy = "DEBUG",
                    Firstname = "Paul",
                    Lastname = "Posaunist",
                    DateOfBirth = new DateOnly(2000 - n, (n % 12) + 1, (n % 28) + 1)
                });
            }
        }
    }
}
