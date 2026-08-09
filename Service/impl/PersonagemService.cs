using API.NET.DTO;
using API.NET.Mapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoApi1.Data;

namespace API.NET.Service.impl
{
    public class PersonagemService : IPersonagemService
    {
        private readonly AppDbContext _appDbContext;

        public PersonagemService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PersonagemResponseDto> AddPersonagem(PersonagemCreateDto dto)
        {
            var personagem = dto.ToEntity();

            _appDbContext.Personagens.Add(personagem);
            await _appDbContext.SaveChangesAsync();

            return personagem.ToDto();
        }

        public async Task<IEnumerable<PersonagemResponseDto>> GetPersonagens()
        {
            var personagens = await _appDbContext.Personagens.ToListAsync();

            return personagens.Select(
                p => p.ToDto()
            );
        }

        public async Task<PersonagemResponseDto?> GetPersonagemById(int id)
        {
            var personagem = await _appDbContext.Personagens.FindAsync(id);

            return personagem?.ToDto();
        }

        public async Task<PersonagemResponseDto?> UpdatePersonagemById(int id, PersonagemCreateDto dto)
        {
            var personagemExistente = await _appDbContext.Personagens.FindAsync(id);

            if (personagemExistente == null)
            {
                return null;
            }
            await _appDbContext.SaveChangesAsync();

            return personagemExistente.ToDto();
        }

        public async Task<bool> DeletePersonagem(int id)
        {
            var personagemExistente = await _appDbContext.Personagens.FindAsync(id);

            if (personagemExistente == null)
            {
                return false;
            }

            _appDbContext.Personagens.Remove(personagemExistente);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
    }
}