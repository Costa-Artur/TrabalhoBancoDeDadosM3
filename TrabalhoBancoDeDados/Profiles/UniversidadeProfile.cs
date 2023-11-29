using AutoMapper;
using TrabalhoBancoDeDados.api.Entities;

namespace TrabalhoBancoDeDados.api.Profiles
{
    public class UniversidadeProfile : Profile
    {
        public UniversidadeProfile() {
            CreateMap<Universidade, Universidade>();

            CreateMap<Bloco, Bloco>();

            CreateMap<Sala, Sala>();
        }
    }
}
