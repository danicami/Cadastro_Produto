using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovimentosManuais.Models
{
    public class MovimentoManual : BaseModelo
    {
        [Key, Column(Order = 0)]
        public override string CodigoProduto { get; set; }
        [Key, Column(Order = 1)]
        public decimal DataMes { get; set; }
        [Key, Column(Order = 2)]
        public decimal DataAno { get; set; }
        [Key, Column(Order = 3)]
        public decimal NumeroLancamento { get; set; }
        [Key, Column(Order = 4)]
        public string CodigoCosif { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public string CodigoUsuario { get; set; }
        public decimal Valor { get; set; }
        [NotMapped]
        public string Acao { get; set;}

    }
}
