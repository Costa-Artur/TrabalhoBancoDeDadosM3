using AutoMapper;
using TrabalhoBancoDeDados.api.Entities;

namespace TrabalhoBancoDeDados.api.Profiles
{
    public class UniversidadeProfile : Profile
    {
        public UniversidadeProfile() {
            CreateMap<Universidade, Universidade>()
            .ForMember(dest => dest.Blocos, opt => opt.MapFrom(src => src.Blocos)); // Mapeia explicitamente a propriedade Blocos

            CreateMap<Bloco, Bloco>()
                .ForMember(dest => dest.Salas, opt => opt.MapFrom(src => src.Salas)); // Mapeia explicitamente a propriedade Salas
        }
    }
}
