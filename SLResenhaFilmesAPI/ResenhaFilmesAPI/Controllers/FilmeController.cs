using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Service.Contracts;

//controllador que expõe os endpoints da nossa api expondo os serviços da api
//usando os verbos http get post put e delete
namespace ResenhaFilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        //construtor e já injetou o serviço que acessa o repository que acessa o context 
        // para que possamos persistir e acessar o banco de dados
        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        //Task mostra que essa é uma operação assincrona o ActionResult permite que se o retorne o tipo do response ou qualquer outro resultado da Action. Podendo retornar um tipo especifico ou um tipo derivado
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<FilmeDTO>>> GetAll()
        {
            var dtos = await _filmeService.GetAll();

            if (dtos is null)
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro ao obter Filmes");

            return Ok(dtos);
        }


        [HttpGet("{id:int}", Name = "GetFilme")]// passando o id por paramentro
        public async Task<ActionResult<FilmeDTO>> GetById(int id)
        {
            var dto = await _filmeService.GetById(id);
            if (dto == null)
            {
                return NotFound($"Não existe Filme com id={id}");
            }
            return Ok(dto);
        }


        [HttpGet("FilmesPorTitulo")]
        public async Task<ActionResult<IAsyncEnumerable<FilmeDTO>>> GetByTitulo(string titulo)
        {
            var dto = await _filmeService.GetByTitulo(titulo);

            if (dto == null)
                return NotFound($"Não existem titulos com critério {titulo}");

            return Ok(dto);
        }

        [HttpGet("FilmesPorGenero")]
        public async Task<ActionResult<IAsyncEnumerable<FilmeDTO>>> GetByGenero(string genero)
        {
            var dto = await _filmeService.GetByGenero(genero);
            if (dto == null)
            {
                return NotFound($"Não extitem alunos com critério {genero}");
            }
            return Ok(dto);
        }


        [HttpGet("FilmesPorAno")]
        public async Task<ActionResult<IAsyncEnumerable<FilmeDTO>>> GetByAno(string ano)
        {
            var dto = await _filmeService.GetByAno(ano);
            if (dto == null)
            {
                return NotFound("Ano not found");
            }
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FilmeDTO dto)
        {
            var filme = await _filmeService.Create(dto);

            if (filme == null)
            {
                return BadRequest("Request inválido");
            }
            return Ok(filme);
            
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] FilmeDTO dto)
        {
            if (id != dto.FilmeModelId)
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
