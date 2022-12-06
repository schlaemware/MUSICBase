using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.Models.Messages {
  public class LoggedInUserChangedMessage {
    public ObservableUser? LoggedInUser { get; }

    public LoggedInUserChangedMessage(ObservableUser? loggedInUser) {
      LoggedInUser = loggedInUser;
    }
  }
}
