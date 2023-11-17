using AutoMapper;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Models;
using ResenhaFilmesAPI.Repositories;
using ResenhaFilmesAPI.Repositories.Contracts;
using ResenhaFilmesAPI.Service.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ResenhaFilmesAPI.Services
{
    public class FilmeService : IFilmeService
    {

        private readonly IFilmeRepository _filmeRepository;
        private readonly IMapper _mapper;


        public FilmeService(IFilmeRepository filmeRepository, IMapper mapper)
        {
            _filmeRepository = filmeRepository;
            _mapper = mapper;
        }

        public async Task Create(FilmeDTO dto)
        {
            var entity = _mapper.Map<FilmeModel>(dto);
           await _filmeRepository.Create(entity);

            dto.Id = entity.Id;
        }

        public async Task Delete(int id)
        {
            var entity = _filmeRepository.GetById(id).Result;
            await _filmeRepository.Delete(id);
        }

        public async Task<IEnumerable<FilmeDTO>> GetAll()
        {
            var entity = await _filmeRepository.GetAll();
            return _mapper.Map<IEnumerable<FilmeDTO>>(entity);
        }

        public async Task<IEnumerable<FilmeDTO>> GetByAno(string ano)
        {
            var entity = await _filmeRepository.GetByAno(ano);
            return _mapper.Map<IEnumerable<FilmeDTO>>(entity);
        }

        public async Task<IEnumerable<FilmeDTO>> GetByGenero(string genero)
        {
            var entity = await _filmeRepository.GetByGenero(genero);
            return _mapper.Map<IEnumerable<FilmeDTO>>(entity);
        }

        public async Task<FilmeDTO> GetById(int id)
        {
            var entity = await _filmeRepository.GetById(id);
            return _mapper.Map<FilmeDTO>(entity);
        }

        public async Task<IEnumerable<FilmeDTO>> GetByTitulo(string titulo)
        {
            var entity = await _filmeRepository.GetByGenero(titulo);
            return _mapper.Map<IEnumerable<FilmeDTO>>(entity);
        }

        public async Task Update(FilmeDTO dto)
        {
            var entity = _mapper.Map<FilmeModel>(dto);

            await _filmeRepository.Update(entity);
        }
    }
}
