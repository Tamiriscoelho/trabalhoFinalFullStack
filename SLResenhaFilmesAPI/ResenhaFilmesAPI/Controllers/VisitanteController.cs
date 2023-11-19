using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Service.Contracts;
using ResenhaFilmesAPI.Services;

namespace ResenhaFilmesAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    
    [ApiController]
    public class VisitanteController : ControllerBase
    {
       private readonly IVisitanteService _visitanteService;

        public VisitanteController(IVisitanteService visitanteService)
        {
            _visitanteService = visitanteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitanteDTO>>> Get()
        {
            var dtos = await _visitanteService.GetAll();

            if (dtos is null)
                return NotFound("Visitante not found");

            return Ok(dtos);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<VisitanteDTO>> GetById(int id)
        {
            var dto = await _visitanteService.GetById(id);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }


        [HttpGet("nome")]
        public async Task<ActionResult<VisitanteDTO>> GetByName(string nome)
        {
            var dto = await _visitanteService.GetByName(nome);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }

        [HttpGet("logar")]
        public async Task<ActionResult<VisitanteDTO>> Get(string login, string senha)
        {
            var dto = await _visitanteService.GetByLoginSenha(login, senha);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VisitanteDTO dto)
        {
            var visitante = await _visitanteService.Create(dto);

            if (visitante == null)
            {
                return BadRequest();
            }
            return Ok(visitante);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] VisitanteDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();

            if (dto is null)
                return BadRequest();

            await _visitanteService.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VisitanteDTO>> Delete(int id)
        {
            var dto = await _visitanteService.GetById(id);
            if (dto == null)
            {
                return NotFound("Visitante not found");
            }

            await _visitanteService.Delete(id);

            return Ok(dto);
        }

    }

}
