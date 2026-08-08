using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoApi1.Data;
using ProjetoApi1.Models;

namespace ProjetoApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagemController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonagemController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appDbContext.Personagens.Add(personagem);
            await _appDbContext.SaveChangesAsync();

            return Created("Personagem adicionar com sucesso!", personagem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
        {
            var personagens = await _appDbContext.Personagens.ToListAsync();

            return Ok(personagens);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Personagem>> GetPersonagemById(int id)
        {
            var personagem = await _appDbContext.Personagens.FindAsync(id);

            if (personagem == null)
            {
                return NotFound("Personagem não localizado no banco");
            }

            return Ok(personagem);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdatePersonagemById(int id, [FromBody] Personagem personagemAtt)
        {
            var personagemExistente = await _appDbContext.Personagens.FindAsync(id);

            if (personagemExistente == null)
            {
                return NotFound("Personagem não localizado no banco");
            }

            _appDbContext.Entry(personagemExistente).CurrentValues.SetValues
            (personagemAtt);

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, personagemExistente);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletePersonagem(int id)
        {
            var personagemExistente = await _appDbContext.Personagens.FindAsync(id);

            if (personagemExistente == null)
            {
                NotFound("Personagem não localizado no banco");
            }

            _appDbContext.Personagens.Remove(personagemExistente);

            await _appDbContext.SaveChangesAsync();

            return Ok("Personagem deletado !");
        }
    }
}