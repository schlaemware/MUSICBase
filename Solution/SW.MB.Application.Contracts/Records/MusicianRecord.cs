using SW.MB.Domain.Shared.Interfaces;

namespace SW.MB.Application.Contracts.Records {
    public record class MusicianRecord : PersonRecord<int>, IMusician {

    }
}
