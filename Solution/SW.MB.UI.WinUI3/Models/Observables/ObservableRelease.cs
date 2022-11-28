using System;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.Domain.Models.Records;

namespace SW.MB.UI.WinUI3.Models.Observables {
    public class ObservableRelease : ObservableObject {
        public string? Designation { get; }
        public Version? Version { get; }
        public string? Description { get; }
        public bool Draft { get; }
        public bool PreRelease { get; }
        public DateTime Created { get; }
        public DateTime? Published { get; }
        public Uri? DownloadUri { get; }

        #region CONSTRUCTORS
        public ObservableRelease(ReleaseRecord record) {
            Designation = record.Designation;
            Version = record.Version;
            Description = record.Description;
            Draft = record.Draft;
            PreRelease = record.PreRelease;
            Created = record.Created.ToLocalTime().DateTime;
            Published = record.Published != null ? record.Published.Value.ToLocalTime().DateTime : default;
            DownloadUri = record.DownloadUri;
        }
        #endregion CONSTRUCTORS
    }
}
