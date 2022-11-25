using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SW.MB.Domain.Models.Records;

namespace SW.MB.UI.WPF.Models.Observables {
  public class ObservableRelease: ObservableObject {
    public string? Name { get; init; }
    public Version? Version { get; init; }
    public string? Description { get; init; }
    public bool Draft { get; init; }
    public bool PreRelease { get; init; }
    public DateTimeOffset Created { get; init; }
    public DateTimeOffset? Published { get; init; }

    #region COMMANDS
    public ICommand DownloadCommand { get; }
    #endregion COMMANDS

    #region CONSTRUCTORS
    public ObservableRelease() {
      DownloadCommand = new RelayCommand(() => System.Diagnostics.Debug.WriteLine("Download..."));
    }

    public ObservableRelease(ReleaseRecord record) {
      Name = record.Designation;
      Version = record.Version;
      Description = record.Description;
      Draft = record.Draft;
      PreRelease = record.PreRelease;
      Created = record.Created;
      Published = record.Published;

      DownloadCommand = new RelayCommand(() => System.Diagnostics.Debug.WriteLine("Download..."));
    }
    #endregion CONSTRUCTORS
  }
}
