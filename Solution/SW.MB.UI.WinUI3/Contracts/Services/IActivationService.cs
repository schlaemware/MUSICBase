using System.Threading.Tasks;

namespace SW.MB.UI.WinUI3.Contracts.Services {
  public interface IActivationService {
    public Task ActivateAsync(object activationArgs);
  }
}
