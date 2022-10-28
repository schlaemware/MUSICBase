using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions.EntityExtensions
{
    internal static class BandEntityExtensions
    {
        public static BandRecord ToRecord(this BandEntity entity)
        {
            return new BandRecord()
            {
                ID = entity.ID,
                Created = entity.Created,
                CreatedBy = entity.CreatedBy,
                Updated = entity.Updated,
                UpdatedBy = entity.UpdatedBy,
                Name = entity.Name,
                Musicians = entity.Musicians.Select(x => x.ToRecord()).ToArray(),
            };
        }
    }
}
