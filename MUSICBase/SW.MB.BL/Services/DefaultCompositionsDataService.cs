using System.Runtime.CompilerServices;
using SW.MB.BL.Contracts.Services;
using SW.MB.DA.Contracts.Repositories;
using SW.MB.DA.Models.Records;

[assembly: InternalsVisibleTo("SW.MB.UI.WPF")]

namespace SW.MB.BL.Services {
    internal class DefaultCompositionsDataService : ICompositionsDataService {
        private readonly ICompositionsRepository _CompositionsRepository;

        #region CONSTRUCTORS
        public DefaultCompositionsDataService(ICompositionsRepository compositionsRepository) {
            _CompositionsRepository = compositionsRepository;
        }
        #endregion CONSTRUCTORS

        public void Dispose() {
            System.Diagnostics.Debug.WriteLine($"{GetType().Name} disposed...");
        }

        public List<CompositionRecord> GetAll() {
            return _CompositionsRepository.GetAll();
        }
    }
}
