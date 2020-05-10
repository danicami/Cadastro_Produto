using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovimentosManuais.Models
{
    public abstract class BaseModelo
    {
        public virtual string CodigoProduto { get; set; }

    }
}
