namespace SW.MB.Domain.Models.Records {
  public record class ReleaseRecord {
    public string? Designation { get; init; }
    public Version? Version { get; init; }
    public string? Description { get; init; }
    public bool Draft { get; init; }
    public bool PreRelease { get; init; }
    public DateTimeOffset Created { get; init; }
    public DateTimeOffset? Published { get; init; }
    public Uri? DownloadUri { get; init; }
  }
}
