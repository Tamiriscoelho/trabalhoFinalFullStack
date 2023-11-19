using AutoMapper;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Models;
using ResenhaFilmesAPI.Repositories;
using ResenhaFilmesAPI.Repositories.Contracts;
using ResenhaFilmesAPI.Service.Contracts;

namespace ResenhaFilmesAPI.Services
{
    public class AdministradorService : IAdmistradorService
    {

        private readonly IAdmistradorRepository _administradorRepository;
        private readonly IMapper _mapper;


        public AdministradorService(IAdmistradorRepository administradorRepository, IMapper mapper)
        {
            _administradorRepository = administradorRepository;
            _mapper = mapper;
        }

        public async Task<AdministradorDTO> Create(AdministradorDTO dto)
        {
            //recebe um dto  mapper converte objeto para uma model
            // e passa o  para o repository
            var entity = _mapper.Map<AdministradorModel>(dto);
            var administrador = await _administradorRepository.Create(entity);
            return _mapper.Map<AdministradorDTO>(administrador);   
        }

        public async Task Update(AdministradorDTO dto)
        {
            var entity =  _mapper.Map<AdministradorModel>(dto);

            await _administradorRepository.Update(entity);
        }

        public async Task Delete(int id)
        {
            var entity = _administradorRepository.GetById(id).Result;
            await _administradorRepository.Delete(id);
        }

        public async Task<IEnumerable<AdministradorDTO>> GetAll()
        {
            var entity = await _administradorRepository.GetAll();
            return _mapper.Map<IEnumerable<AdministradorDTO>>(entity);
        }

        public async Task<AdministradorDTO> GetById(int id)
        {
            var entity = await _administradorRepository.GetById(id);
            return _mapper.Map<AdministradorDTO>(entity);
        }           

        public async Task<AdministradorDTO> GetByName(string nome)
        {
            var entity = await _administradorRepository.GetByName(nome);
            return _mapper.Map<AdministradorDTO>(entity);
        }

        public async Task<AdministradorLoginDTO> GetByLoginSenha(string login, string senha)
        {
            var entity = await _administradorRepository.GetByLoginSenha(login,senha);
            return _mapper.Map<AdministradorLoginDTO>(entity);
        }

    }
}
