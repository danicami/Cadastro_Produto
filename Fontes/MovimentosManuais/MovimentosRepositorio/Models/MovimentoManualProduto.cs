using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovimentosManuais.Models
{
    public class MovimentoManualProduto : BaseModelo
    {
        public decimal DataMes { get; set; }
        public decimal DataAno { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal NumeroLancamento { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

    }
}
