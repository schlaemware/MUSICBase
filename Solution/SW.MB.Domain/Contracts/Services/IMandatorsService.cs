using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface IMandatorsService {
        public IEnumerable<MandatorRecord> GetAll();
    }
}
