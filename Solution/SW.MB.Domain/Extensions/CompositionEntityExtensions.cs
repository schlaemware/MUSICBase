using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Extensions {
    internal static class CompositionEntityExtensions {
        public static CompositionRecord ToRecord(this CompositionEntity entity) {
            return new CompositionRecord() {
                ID = entity.ID,
                Created = entity.Created,
                CreatedBy = entity.CreatedBy,
                Updated = entity.Updated,
                UpdatedBy = entity.UpdatedBy,
                Title = entity.Title
            };
        }
    }
}
