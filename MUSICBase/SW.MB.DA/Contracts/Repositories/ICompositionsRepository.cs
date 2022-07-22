using SW.MB.DA.Models.Records;

namespace SW.MB.DA.Contracts.Repositories {
    public interface ICompositionsRepository {
        public List<CompositionRecord> GetAll();
    }
}
