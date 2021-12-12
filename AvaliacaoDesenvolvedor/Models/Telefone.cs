using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoDesenvolvedor.Models
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }        
        [Display(Name = "Número")]
        [RegularExpression(@"^\d{5}-\d{4}$", ErrorMessage = "O Número de telefone deve estar no formato #####-####!")]
        [Required(ErrorMessage = "O campo número é obrigatório")]
        [MaxLength(10)]
        public string Numero { get; set; }
        public int ContatoId { get; set; }
        public Contato Contato { get; set; }
    }
}