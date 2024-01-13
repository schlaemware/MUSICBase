using AutoMapper;
using SW.MB.Application.Contracts.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.Models {
    public class UIMapperProfile : Profile {
        public UIMapperProfile() {
            CreateMap<CompositionRecord, ObservableComposition>()
                .ReverseMap();

            CreateMap<MusicianRecord, ObservableMusician>()
                .ReverseMap();
        }
    }
}
