using System.Threading.Tasks;

namespace SW.MB.UI.WPF.Contracts.Services {
  public interface IActivationService {
    public Task ActivateAsync(params object[] activationArgs);
  }
}
