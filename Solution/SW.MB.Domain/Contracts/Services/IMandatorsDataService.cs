using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface IMandatorsDataService {
        public static event EventHandler<MandatorRecord>? MandatorChanged;
        public static event EventHandler? MandatorsChanged;

        public static void RaiseMandatorChanged(MandatorRecord mandator) {
            MandatorChanged?.Invoke(null, mandator);
        }

        public static void RaiseMandatorsChanged() {
            MandatorsChanged?.Invoke(null, EventArgs.Empty);
        }

        public IEnumerable<MandatorRecord> GetAll();

        public void UpdateRange(params MandatorRecord[] records);
    }
}
