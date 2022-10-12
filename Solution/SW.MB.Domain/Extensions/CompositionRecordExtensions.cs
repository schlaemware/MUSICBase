using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions {
    internal static class CompositionRecordExtensions {
        public static CompositionEntity ToEntity(this CompositionRecord record) {
            return new CompositionEntity() {
                ID = record.ID,
                Created = record.Created,
                CreatedBy = record.CreatedBy,
                Updated = record.Updated,
                UpdatedBy = record.UpdatedBy,
                Title = record.Title
            };
        }
    }
}
