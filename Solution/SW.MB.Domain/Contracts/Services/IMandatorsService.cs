using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface IMandatorsService {
        public static event EventHandler<MandatorRecord>? MandatorChanged;

        public IEnumerable<MandatorRecord> GetAll();
        public IEnumerable<MandatorRecord> GetAllRaw();

        public void RaiseMandatorChanged(MandatorRecord mandator) {
            MandatorChanged?.Invoke(this, mandator);
        }

        public void UpdateRange(params MandatorRecord[] records);
    }
}
