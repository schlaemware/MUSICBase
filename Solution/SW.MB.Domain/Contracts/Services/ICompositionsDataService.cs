using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface ICompositionsDataService {
        public IEnumerable<CompositionRecord> GetAll(params MandatorRecord?[]? mandators);

        public void Update(CompositionRecord record);

        public void UpdateRange(params CompositionRecord[] records);
    }
}
