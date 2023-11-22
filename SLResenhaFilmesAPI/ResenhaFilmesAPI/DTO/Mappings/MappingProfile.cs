using AutoMapper;
using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioModel, UsuarioDTO>().ReverseMap();

            CreateMap<UsuarioModel, UsuarioLoginDTO>().ReverseMap();

            CreateMap<FilmeModel, FilmeDTO>().ReverseMap();

            CreateMap<ResenhaModel, ResenhaDTO>().ReverseMap();
        }


    }
}
