using AutoMapper;
using SW.MB.Application.Contracts.Records;
using SW.MB.UI.WPF.Interfaces;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels
{
    public class MembersViewModel : DataViewModel<ObservableMusician, MusicianRecord, int>, INavigableObject
    {
        public MembersViewModel(IMapper mapper) : base(mapper)
        {

        }
    }
}
