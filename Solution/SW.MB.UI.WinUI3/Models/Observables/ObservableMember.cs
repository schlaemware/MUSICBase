using CommunityToolkit.Mvvm.ComponentModel;

namespace SW.MB.UI.WinUI3.Models.Observables {
    public class ObservableMember: ObservableObject {
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }

    public string? Fullname => $"{Firstname} {Lastname}";
  }
}
