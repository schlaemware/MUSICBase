using SW.MB.Domain.Contracts.Models;

namespace SW.MB.Domain.Models.Records.Abstracts {
  public abstract record class PersonRecord: EntityRecord, IPerson {
    public string Firstname { get; init; } = string.Empty;
    public string Lastname { get; init; } = string.Empty;
    public DateOnly? DateOfBirth { get; init; }
  }
}
