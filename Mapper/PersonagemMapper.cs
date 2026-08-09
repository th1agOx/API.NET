using API.NET.DTO;
using ProjetoApi1.Models;

namespace API.NET.Mapper
{
    public static class PersonagemMapper
    {
        public static Personagem ToEntity(this PersonagemCreateDto dto)
        {
            return new Personagem
            {
                Nome = dto.Nome,
                Tipo = dto.Tipo
            };
        }

        public static PersonagemResponseDto ToDto(this Personagem entity)
        {
            return new PersonagemResponseDto(entity.Id, entity.Nome, entity.Tipo);
        }
    }
}