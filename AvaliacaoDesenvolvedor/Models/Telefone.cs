using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoDesenvolvedor.Models
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }        
        public string Numero { get; set; }
        public int ContatoId { get; set; }
        public Contato Contato { get; set; }
    }
}