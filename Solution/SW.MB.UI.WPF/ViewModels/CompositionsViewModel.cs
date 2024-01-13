using AutoMapper;
using SW.MB.Application.Contracts.Records;
using SW.MB.UI.WPF.Interfaces;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
    public class CompositionsViewModel : DataViewModel<ObservableComposition, CompositionRecord, int>, INavigableObject {
        public CompositionsViewModel(IMapper mapper) : base(mapper) {

        }
    }
}
