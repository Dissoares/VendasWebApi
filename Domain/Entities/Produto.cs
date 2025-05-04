using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
    }
}
