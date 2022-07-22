using SW.MB.BL.Contracts.Services;

namespace SW.MB.BL.Services {
  internal class DefaultMusiciansDataService: IMusiciansDataService {
    #region CONSTRUCTORS
    public DefaultMusiciansDataService() {

    }
    #endregion CONSTRUCTORS

    public void Dispose() {
      System.Diagnostics.Debug.WriteLine($"{GetType().Name} disposed...");
    }
  }
}
