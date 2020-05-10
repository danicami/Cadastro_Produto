using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovimentosManuais.Models
{
    public class ProdutoCosif: BaseModelo
    {
        [Key, Column(Order = 0)]
        public override string CodigoProduto { get; set; }
        [Key, Column(Order = 1)]
        public string CodigoCosif { get; set; }
        public string CodigoClassificacao { get; set; }
        public char Status { get; set; }

    }
}
