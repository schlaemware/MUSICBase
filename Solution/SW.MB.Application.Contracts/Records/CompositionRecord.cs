using SW.MB.Domain.Shared.Interfaces;

namespace SW.MB.Application.Contracts.Records {
    public record class CompositionRecord : EntityRecord<int>, IComposition {
        public string Title { get; init; }
    }
}
