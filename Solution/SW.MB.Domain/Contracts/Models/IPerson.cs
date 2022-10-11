namespace SW.MB.Domain.Contracts.Models {
  public interface IPerson : Data.Contracts.Models.IEntity {
    public string Firstname { get; }
    public string Lastname { get; }
    public DateOnly? DateOfBirth { get; }
  }
}
