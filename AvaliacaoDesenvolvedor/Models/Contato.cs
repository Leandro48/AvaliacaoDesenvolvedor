using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaliacaoDesenvolvedor.Models
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(50)]
        public string Nome { get; set; }
        public List<Telefone> Telefones { get; set; }
    }
}