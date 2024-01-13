using AutoMapper;
using SW.MB.Application.Contracts.Records;
using SW.MB.Domain.Entities;

namespace SW.MB.Application.WPF {
    public class AppMapperProfile : Profile {
        public AppMapperProfile() {
            CreateMap<Composition, CompositionRecord>()
                .ReverseMap();

            CreateMap<Musician, MusicianRecord>()
                .ReverseMap();
        }
    }
}
