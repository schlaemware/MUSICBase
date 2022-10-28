using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions.RecordExtensions
{
    internal static class BandRecordExtensions
    {
        public static BandEntity ToEntity(this BandRecord record)
        {
            return new BandEntity()
            {
                ID = record.ID,
                Created = record.Created,
                CreatedBy = record.CreatedBy,
                Updated = record.Updated,
                UpdatedBy = record.UpdatedBy,
                Name = record.Name,
                Musicians = record.Musicians?.Select(x => x.ToEntity())?.ToList() ?? new List<MusicianEntity>(),
            };
        }
    }
}
