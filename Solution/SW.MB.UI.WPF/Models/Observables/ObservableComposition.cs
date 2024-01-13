using SW.MB.Application.Contracts.Records;
using SW.MB.Domain.Shared.Interfaces;

namespace SW.MB.UI.WPF.Models.Observables
{
    public class ObservableComposition : ObservableEntity<CompositionRecord, int>, IComposition
    {
        public string Title { get; set; }
    }
}
