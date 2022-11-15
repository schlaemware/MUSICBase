using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using Octokit;
using SW.Framework.Extensions;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
  public class UpdatesViewModel: PageViewModel {
    private readonly IGitHubClient _Client;

    public ObservableCollection<ObservableRelease> ReleasesCollection { get; } = new();

    public ICollectionView ReleasesView { get; }

    #region CONSTRUCTORS
    public UpdatesViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      _Client = new GitHubClient(new ProductHeaderValue(App.SimplifiedOrganization));
      ReleasesView = CreateReleasesView();
    }
    #endregion CONSTRUCTORS

    public override void Initialize() {
      CheckUpdatesAsync();
    }

    private ICollectionView CreateReleasesView() {
      ICollectionView view = CollectionViewSource.GetDefaultView(ReleasesCollection);
      view.SortDescriptions.Add(new SortDescription(nameof(ObservableRelease.Version), ListSortDirection.Descending));

      return view;
    }

    private async void CheckUpdatesAsync() {
      IReadOnlyList<Repository> repositories = await _Client.Repository.GetAllForOrg(App.SimplifiedOrganization);
      if (repositories.FirstOrDefault(x => x.Name.ToLower() == "testrepo" /* App.Product.ToLower() */) is Repository repository) {
        IEnumerable<Release> releases = (await _Client.Repository.Release.GetAll(repository.Id)).Where(x => Version.TryParse(x.TagName, out Version? version));
        releases.ForEach(async release => {
          IReadOnlyList<ReleaseAsset> assets = await _Client.Repository.Release.GetAllAssets(repository.Id, release.Id);
          Dispatcher.Invoke(() => ReleasesCollection.Add(new ObservableRelease(release, assets.Any(x => x.Name.EndsWith(".msi")))));
        });
      }
    }
  }
}
