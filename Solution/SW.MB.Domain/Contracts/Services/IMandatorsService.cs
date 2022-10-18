using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface IMandatorsService {
        public static event EventHandler? MandatorChanged;

        public IEnumerable<MandatorRecord> GetAll();
        public IEnumerable<MandatorRecord> GetAllRaw();

        public void RaiseMandatorChanged() {
            MandatorChanged?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateRange(params MandatorRecord[] records);
    }
}
