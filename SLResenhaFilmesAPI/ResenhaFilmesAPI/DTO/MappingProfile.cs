using AutoMapper;
using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdministradorModel, AdministradorDTO>().ReverseMap();
        }

        
    }
}
