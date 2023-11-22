using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Service.Contracts;

namespace ResenhaFilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmeDTO>>> GetAll()
        {
            var dtos = await _filmeService.GetAll();

            if (dtos is null)
                return NotFound(" Filme not found");

            return Ok(dtos);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<FilmeDTO>> GetById(int id)
        {
            var dto = await _filmeService.GetById(id);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }


        [HttpGet("titulo")]
        public async Task<ActionResult<IEnumerable<FilmeDTO>>> GetByTitulo(string titulo)
        {
            var dto = await _filmeService.GetByTitulo(titulo);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }

        [HttpGet("genero")]
        public async Task<ActionResult<IEnumerable<FilmeDTO>>> GetByGenero(string genero)
        {
            var dto = await _filmeService.GetByGenero(genero);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }


        [HttpGet("ano")]
        public async Task<ActionResult<IEnumerable<FilmeDTO>>> GetByAno(string ano)
        {
            var dto = await _filmeService.GetByAno(ano);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FilmeDTO dto)
        {
            var filme = await _filmeService.Create(dto);

            if (filme == null)
            {
                return BadRequest();
            }
            return Ok(filme);
            
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] FilmeDTO dto)
        {
            if (id != dto.IdFilme)
                return BadRequest();

            if (dto is null)
                return BadRequest();

            await _filmeService.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FilmeDTO>> Delete(int id)
        {
            var dto = await _filmeService.GetById(id);
            if (dto == null)
            {
                return NotFound("Filme not found");
            }

            await _filmeService.Delete(id);

            return Ok(dto);
        }
    }
}
