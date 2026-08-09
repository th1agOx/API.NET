using API.NET.DTO;
using API.NET.Service;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagemController : ControllerBase
    {
        private readonly IPersonagemService _personagemService;

        public PersonagemController(IPersonagemService personagemService)
        {
            _personagemService = personagemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagem([FromBody] PersonagemCreateDto dto)
        {
            var result = await _personagemService.AddPersonagem(dto);

            return CreatedAtAction(nameof(GetPersonagemById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonagemResponseDto>>> GetPersonagens()
        {
            var personagens = await _personagemService.GetPersonagens();

            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonagemResponseDto>> GetPersonagemById(int id)
        {
            var personagem = await _personagemService.GetPersonagemById(id);

            if (personagem == null)
            {
                return NotFound("Personagem não localizado no banco");
            }

            return Ok(personagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonagemById(int id, [FromBody] PersonagemCreateDto dto)
        {
            var personagemAtualizado = await _personagemService.UpdatePersonagemById(id, dto);

            if (personagemAtualizado == null)
            {
                return NotFound("Personagem não localizado no banco");
            }

            return Ok(personagemAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonagem(int id)
        {
            var sucesso = await _personagemService.DeletePersonagem(id);

            if (!sucesso)
            {
                return NotFound("Personagem não localizado no banco");
            }

            return NoContent();
        }
    }
}