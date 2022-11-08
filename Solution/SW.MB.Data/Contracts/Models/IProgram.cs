namespace SW.MB.Data.Contracts.Models {
  public interface IProgram : IEntity {
    public string Name { get; }

    public DateTime Date { get; }
  }
}
