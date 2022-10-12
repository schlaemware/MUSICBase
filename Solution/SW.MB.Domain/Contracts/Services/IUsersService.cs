using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface IUsersService {
        public IEnumerable<UserRecord> GetAll();
    }
}
