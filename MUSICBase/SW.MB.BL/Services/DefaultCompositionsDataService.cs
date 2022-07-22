using System.Runtime.CompilerServices;
using SW.MB.BL.Contracts.Services;
using SW.MB.DA.Contracts.Repositories;

[assembly: InternalsVisibleTo("SW.MB.UI.WPF")]

namespace SW.MB.BL.Services {
  internal class DefaultCompositionsDataService : ICompositionsDataService {
    private readonly ICompositionsRepository _CompositionsRepository;

    public DefaultCompositionsDataService(ICompositionsRepository compositionsRepository) {
      _CompositionsRepository = compositionsRepository;
    }

    public void Dispose() {
      System.Diagnostics.Debug.WriteLine($"{GetType().Name} disposed...");
    }
  }
}
