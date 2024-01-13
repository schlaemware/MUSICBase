using SW.MB.Domain.Shared.Interfaces;

namespace SW.MB.Domain.Entities {
    public class Composition : Entity<int>, IComposition {
        public string Title { get; set; }
    }
}