using AutoMapper;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Models;
using ResenhaFilmesAPI.Repositories;
using ResenhaFilmesAPI.Repositories.Contracts;
using ResenhaFilmesAPI.Service.Contracts;

namespace ResenhaFilmesAPI.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;


        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Create(UsuarioDTO dto)
        {
            //recebe um dto  mapper converte objeto para uma model
            // e passa o  para o repository
            var entity = _mapper.Map<UsuarioModel>(dto);
            var usuario = await _usuarioRepository.Create(entity);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> CreateUserComum(UsuarioDTO dto)
        {
            dto.Roles = "comum";
           return await Create(dto);
             
        }

        public async Task<UsuarioDTO> CreateUserAdmin(UsuarioDTO dto)
        {
            dto.Roles = "admin";
            return await Create(dto);
        }

        public async Task Delete(int id)
        {
            var entity = _usuarioRepository.GetById(id).Result;
            await _usuarioRepository.Delete(id);
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAll()
        {
            var entity = await _usuarioRepository.GetAll();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(entity);
        }

        public async Task<UsuarioDTO> GetById(int id)
        {
            var entity = await _usuarioRepository.GetById(id);
            return _mapper.Map<UsuarioDTO>(entity);
        }

        public async Task<UsuarioLoginDTO> GetByLoginSenha(string login, string senha)
        {
            var entity = await _usuarioRepository.GetByLoginSenha(login, senha);
            return _mapper.Map<UsuarioLoginDTO>(entity);

        }

        public async Task<UsuarioDTO> GetByName(string nome)
        {
            var entity = await _usuarioRepository.GetByName(nome);
            return _mapper.Map<UsuarioDTO>(entity);

        }
        public async Task Update(UsuarioDTO dto)
        {
            var entity = _mapper.Map<UsuarioModel>(dto);

            await _usuarioRepository.Update(entity);
        }
    }
}
