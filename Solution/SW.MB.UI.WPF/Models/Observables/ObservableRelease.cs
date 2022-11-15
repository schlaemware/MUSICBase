using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Octokit;

namespace SW.MB.UI.WPF.Models.Observables {
  public class ObservableRelease: ObservableObject {
    public string Name { get; }
    public Version Version { get; }
    public string? Description { get; }
    public bool Draft { get; }
    public bool PreRelease { get; }
    public DateTimeOffset Created { get; }
    public DateTimeOffset? Published { get; }
    public bool HasInstaller { get; }

    #region COMMANDS
    public ICommand DownloadCommand { get; }
    #endregion COMMANDS

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
  }
}
