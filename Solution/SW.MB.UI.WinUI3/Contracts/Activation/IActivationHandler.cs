using System.Threading.Tasks;

namespace SW.MB.UI.WinUI3.Contracts.Activation {
  public interface IActivationHandler {
    public bool CanHandle(object args);

    public Task HandleAsync(object args);
  }
}
