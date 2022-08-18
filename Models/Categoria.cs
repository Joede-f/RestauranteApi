

using System.ComponentModel.DataAnnotations;

namespace RestauranteNascimento.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeCat { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
