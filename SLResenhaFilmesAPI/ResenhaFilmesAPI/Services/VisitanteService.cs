using AutoMapper;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Models;
using ResenhaFilmesAPI.Repositories;
using ResenhaFilmesAPI.Repositories.Contracts;
using ResenhaFilmesAPI.Service.Contracts;

namespace ResenhaFilmesAPI.Services
{
    public class VisitanteService : IVisitanteService
    {

        private readonly IVisitanteRepository _visitanteRepository;
        private readonly IMapper _mapper;


        public VisitanteService(IVisitanteRepository visitanteRepository, IMapper mapper)
        {
            _visitanteRepository = visitanteRepository;
            _mapper = mapper;
        }

        public async Task<VisitanteDTO> Create(VisitanteDTO dto)
        {
            //recebe um dto  mapper converte objeto para uma model
            // e passa o  para o repository
            var entity = _mapper.Map<VisitanteModel>(dto);
            var visitante = await _visitanteRepository.Create(entity);
            return _mapper.Map<VisitanteDTO>(visitante);
        }

        public async Task Delete(int id)
        {
            var entity = _visitanteRepository.GetById(id).Result;
            await _visitanteRepository.Delete(id);
        }

        public async Task<IEnumerable<VisitanteDTO>> GetAll()
        {
            var entity = await _visitanteRepository.GetAll();
            return _mapper.Map<IEnumerable<VisitanteDTO>>(entity);
        }

        public async Task<VisitanteDTO> GetById(int id)
        {
            var entity = await _visitanteRepository.GetById(id);
            return _mapper.Map<VisitanteDTO>(entity);
        }

        public async Task<VisitanteLoginDTO> GetByLoginSenha(string login, string senha)
        {
            var entity = await _visitanteRepository.GetByLoginSenha(login, senha);
            return _mapper.Map<VisitanteLoginDTO>(entity);

        }

        public async Task<VisitanteDTO> GetByName(string nome)
        {
            var entity = await _visitanteRepository.GetByName(nome);
            return _mapper.Map<VisitanteDTO>(entity);

        }
        public async Task Update(VisitanteDTO dto)
        {
            var entity = _mapper.Map<VisitanteModel>(dto);

            await _visitanteRepository.Update(entity);
        }
    }
}
