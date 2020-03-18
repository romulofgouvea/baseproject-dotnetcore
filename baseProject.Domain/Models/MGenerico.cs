using System.ComponentModel.DataAnnotations;

namespace BaseProject.Domain.Models
{
    public class MGenerico
    {
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
