using AutoMapper;
using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdministradorModel, AdministradorDTO>().ReverseMap();

            CreateMap<AdministradorModel, AdministradorLoginDTO>().ReverseMap();

            CreateMap<VisitanteDTO, VisitanteDTO>().ReverseMap();

            CreateMap<VisitanteDTO, VisitanteLoginDTO>().ReverseMap();

            CreateMap<FilmeModel, FilmeDTO>().ReverseMap();

            CreateMap<ResenhaModel, ResenhaDTO>().ReverseMap();
        }


    }
}
