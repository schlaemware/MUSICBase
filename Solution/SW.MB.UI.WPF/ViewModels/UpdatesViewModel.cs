using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
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
          Draft = n % 3 == 0,
          Published = DateTime.Now,
          Version = new Version(0, 0, 0, n),
        });
      }
    }
  }
}
