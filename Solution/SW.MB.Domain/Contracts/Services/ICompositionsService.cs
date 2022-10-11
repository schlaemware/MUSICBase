using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
  public interface ICompositionsService {
    public IEnumerable<CompositionRecord> GetAll();

    public void Update(CompositionRecord record);

    public void UpdateRange(params CompositionRecord[] records);
  }
}
