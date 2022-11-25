using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Octokit;

namespace SW.MB.UI.WPF.Models.Observables {
  public class ObservableRelease: ObservableObject {
    public string? Name { get; init; }
    public Version? Version { get; init; }
    public string? Description { get; init; }
    public bool Draft { get; init; }
    public bool PreRelease { get; init; }
    public DateTimeOffset Created { get; init; }
    public DateTimeOffset? Published { get; init; }
    public bool HasInstaller { get; init; }

    #region COMMANDS
    public ICommand DownloadCommand { get; }
    #endregion COMMANDS

    #region CONSTRUCTORS
    public ObservableRelease() {
      DownloadCommand = new RelayCommand(() => System.Diagnostics.Debug.WriteLine("Download..."), () => HasInstaller);
    }

    public ObservableRelease(Release release, bool hasInstaller) {
      Name = release.Name;
      Version = Version.Parse(release.TagName);
      Description = release.Body;
      Draft = release.Draft;
      PreRelease = release.Prerelease;
      Created = release.CreatedAt;
      Published = release.PublishedAt;
      HasInstaller = hasInstaller;

      DownloadCommand = new RelayCommand(() => System.Diagnostics.Debug.WriteLine("Download..."), () => HasInstaller);
    }
    #endregion CONSTRUCTORS
  }
}
