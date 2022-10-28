using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions.EntityExtensions
{
    internal static class MandatorEntityExtensions
    {
        public static MandatorRecord ToRecord(this MandatorEntity entity)
        {
            return new MandatorRecord()
            {
                ID = entity.ID,
                Created = entity.Created,
                CreatedBy = entity.CreatedBy,
                Updated = entity.Updated,
                UpdatedBy = entity.UpdatedBy,
                Name = entity.Name
            };
        }
    }
}
