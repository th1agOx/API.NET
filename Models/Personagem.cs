using System.ComponentModel.DataAnnotations;

namespace ProjetoApi1.Models
{
    public class Personagem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Nome não pode exceder ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Tipo é um campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Tipo precisa ter ")]
        public string Tipo { get; set; }
    }
}