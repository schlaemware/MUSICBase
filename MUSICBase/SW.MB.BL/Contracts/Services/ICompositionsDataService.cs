using SW.MB.DA.Models.Records;

namespace SW.MB.BL.Contracts.Services {
    public interface ICompositionsDataService : IDisposable {
        public List<CompositionRecord> GetAll();
    }
}
