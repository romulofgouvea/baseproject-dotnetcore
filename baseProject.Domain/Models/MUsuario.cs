using System;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Domain.Models
{
    public class MUsuario
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
