
using System.ComponentModel.DataAnnotations;

namespace API.NET.DTO
{
    public record PersonagemCreateDto(

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Nome não pode receber mais de 50 caracteres")]
        string Nome,

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Nome não pode receber mais de 50 caracteres")]
        string Tipo
    );

    public record PersonagemResponseDto(
        int Id, string Nome, string Tipo
    );
}