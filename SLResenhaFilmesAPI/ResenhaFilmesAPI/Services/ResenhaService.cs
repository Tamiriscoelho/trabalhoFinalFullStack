using AutoMapper;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Models;
using ResenhaFilmesAPI.Repositories;
using ResenhaFilmesAPI.Repositories.Contracts;
using ResenhaFilmesAPI.Service.Contracts;

namespace ResenhaFilmesAPI.Services
{
    public class ResenhaService : IResenhaService
    {
        private readonly IResenhaRepository _resenhaRepository;
        private readonly IMapper _mapper;


        public ResenhaService(IResenhaRepository resenhaRepository, IMapper mapper)
        {
            _resenhaRepository = resenhaRepository;
            _mapper = mapper;
        }

        public async Task Create(ResenhaDTO dto)
        {
            var entity = _mapper.Map<ResenhaModel>(dto);
            await _resenhaRepository.Create(entity);

            dto.Id = entity.Id;
        }

        public async Task Delete(int id)
        {
            var entity = _resenhaRepository.GetById(id).Result;
            await _resenhaRepository.Delete(id);
        }

        public async Task<IEnumerable<ResenhaDTO>> GetAll()
        {
            var entity = await _resenhaRepository.GetAll();
            return _mapper.Map<IEnumerable<ResenhaDTO>>(entity);
        }

        public async Task<ResenhaDTO> GetById(int id)
        {
            var entity = await _resenhaRepository.GetById(id);
            return _mapper.Map<ResenhaDTO>(entity);
        }

        public async Task<IEnumerable<ResenhaDTO>> GetByNota(int nota)
        {
            var entity = await _resenhaRepository.GetByNota(nota);
            return _mapper.Map<IEnumerable<ResenhaDTO>>(entity);
        }

        public async Task Update(ResenhaDTO dto)
        {
            var entity = _mapper.Map<ResenhaModel>(dto);

            await _resenhaRepository.Update(entity);
        }
    }


}

