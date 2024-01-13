using AutoMapper;
using SW.MB.Application.Contracts.Records;
using SW.MB.UI.WPF.Interfaces;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
    public class MusiciansViewModel : DataViewModel<ObservableMusician, MusicianRecord, int>, INavigableObject {
        public MusiciansViewModel(IMapper mapper) : base(mapper) {

        }
    }
}
