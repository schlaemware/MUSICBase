using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions.RecordExtensions
{
    internal static class MandatorRecordExtensions
    {
        public static MandatorEntity ToEntity(this MandatorRecord record)
        {
            return new MandatorEntity()
            {
                ID = record.ID,
                Created = record.Created,
                CreatedBy = record.CreatedBy,
                Updated = record.Updated,
                UpdatedBy = record.UpdatedBy,
                Name = record.Name
            };
        }
    }
}
