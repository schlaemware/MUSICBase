using SW.MB.Data.Contracts;

namespace SW.MB.Domain.Models.Records.Abstracts {
  public abstract record class PersonRecord : EntityRecord, IPerson {
    public string Firstname { get; init; } = string.Empty;
    public string Lastname { get; init; } = string.Empty;
    public DateTime? DateOfBirth { get; init; }
  }
}
