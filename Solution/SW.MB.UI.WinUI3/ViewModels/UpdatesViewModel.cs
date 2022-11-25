using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class UpdatesViewModel: ObservableRecipient {
    public ObservableCollection<ObservableRelease> ReleasesCollection { get; } = new();

    #region CONSTRUCTORS
    public UpdatesViewModel() {
      LoadReleasesAsync();
    }
    #endregion CONSTRUCTORS

    private async void LoadReleasesAsync() {
      IUpdatesService updatesService = App.GetService<IUpdatesService>();
      IEnumerable<ReleaseRecord> releases = await updatesService.CheckUpdatesAsync("Schlaemware", "MUSICBase", Assembly.GetExecutingAssembly().GetName().Version, "msix");
      releases.Select(x => new ObservableRelease(x)).OrderByDescending(x => x.Version).ForEach(x => App.Dispatcher.TryEnqueue(() => ReleasesCollection.Add(x)));
    }
  }
}
