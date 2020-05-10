using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovimentosManuais.Models
{
    public class Produto : BaseModelo
    {
        [Key, Column(Order = 0)]
        public override string CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public char Status { get; set; }

    }
}
