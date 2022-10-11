namespace SW.MB.Data.Contracts {
  public interface IPerson : IEntity {
    public string Firstname { get; }
    public string Lastname { get; }
    public DateTime? DateOfBirth { get; }
  }
}
