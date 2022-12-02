using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface IMembersDataService {
        public IEnumerable<MemberRecord> GetAll(params MandatorRecord?[]? mandators);

        public void UpdateRange(params MemberRecord[] records);
    }
}
