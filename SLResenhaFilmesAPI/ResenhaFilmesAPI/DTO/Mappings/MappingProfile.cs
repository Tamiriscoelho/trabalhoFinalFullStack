using AutoMapper;
using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdministradorModel, AdministradorDTO>().ReverseMap();

            CreateMap<VisitanteDTO, VisitanteDTO>().ReverseMap();

            CreateMap<FilmeModel, FilmeDTO>().ReverseMap();

            CreateMap<ResenhaModel, ResenhaDTO>().ReverseMap();
        }


    }
}
