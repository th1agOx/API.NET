using API.NET.DTO;

namespace API.NET.Service
{
    public interface IPersonagemService
    {
        Task<PersonagemResponseDto> AddPersonagem(PersonagemCreateDto dto);
        Task<IEnumerable<PersonagemResponseDto>> GetPersonagens();
        Task<PersonagemResponseDto?> GetPersonagemById(int id);
        Task<PersonagemResponseDto?> UpdatePersonagemById(int id, PersonagemCreateDto dto);
        Task<bool> DeletePersonagem(int id);
    }
}