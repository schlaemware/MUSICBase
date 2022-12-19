using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SW.MB.Data.Models.Entities.Abstracts;

namespace SW.MB.Data.Models.Configurations.Abstracts
{
    internal abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(x => x.Updated).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
