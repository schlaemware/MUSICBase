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
    public ObservableCollection<ObservableRelease> ReleasesCollection { get; } = new();

    public ICollectionView ReleasesView { get; }

    public ObservableRelease? CurrentRelease => ReleasesCollection.FirstOrDefault(x => x.Version == new Version(0, 0, 0, 1) /* Assembly.GetExecutingAssembly().GetName().Version */);

    public bool UpdateAvailable => ReleasesCollection.Any(x => x.Version > Assembly.GetExecutingAssembly().GetName().Version);

    #region CONSTRUCTORS
    public UpdatesViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      ReleasesView = CreateReleasesView();
    }
    #endregion CONSTRUCTORS

    public override void Initialize() {
      //CheckUpdatesAsync(App.SimplifiedOrganization, App.Product);
      //CheckUpdatesAsync(App.SimplifiedOrganization, "TestRepo");
      CreateTestData();
    }

    private ICollectionView CreateReleasesView() {
      ICollectionView view = CollectionViewSource.GetDefaultView(ReleasesCollection);
      view.SortDescriptions.Add(new SortDescription(nameof(ObservableRelease.Version), ListSortDirection.Descending));

      return view;
    }

    private void CreateTestData() {
      for (int n = 0; n < 10; n++) {
        ReleasesCollection.Add(new ObservableRelease() { 
          Name = $"Release 0.0.0.{n}",
          Created= DateTime.Now,
          PreRelease = n >= 9,
          Description = $"Dieser Release wurde zu Testzwecken erstellt...",
          HasInstaller = n % 2 == 0,
          Draft = n % 3 == 0,
          Published = DateTime.Now,
          Version = new Version(0, 0, 0, n),
        });
      }
    }

    private async void CheckUpdatesAsync(string organization, string product) {
      if (Properties.Settings.Default.LastUpdateCheck.Date < DateTime.Today) {
        // Check updates only once per day
        Properties.Settings.Default.LastUpdateCheck = DateTime.Today;
        GitHubClient client = new(new ProductHeaderValue(organization));
        IReadOnlyList<Repository> repositories = await client.Repository.GetAllForOrg(organization);

        if (repositories.FirstOrDefault(x => x.Name.ToLower() == product.ToLower()) is Repository repository) {
          IEnumerable<Release> releases = (await client.Repository.Release.GetAll(repository.Id)).Where(x => Version.TryParse(x.TagName, out _));
          releases.ForEach(async release => {
            if (Version.TryParse(release.TagName, out Version? version) && version > Assembly.GetExecutingAssembly().GetName().Version) {
              IReadOnlyList<ReleaseAsset> assets = await client.Repository.Release.GetAllAssets(repository.Id, release.Id);
              Dispatcher.Invoke(() => ReleasesCollection.Add(new ObservableRelease(release, assets.Any(x => x.Name.EndsWith(".msi")))));
            } else {
              Dispatcher.Invoke(() => ReleasesCollection.Add(new ObservableRelease(release, false)));
            }
          });

          OnPropertyChanged(nameof(CurrentRelease));
          OnPropertyChanged(nameof(UpdateAvailable));
        }
      }
    }
  }
}
