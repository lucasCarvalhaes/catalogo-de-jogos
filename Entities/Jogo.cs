using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos.Entities
{
    public class Jogo 
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Produtora { get; set; }

        [Required]
        public double Preco { get; set; }
    }
}