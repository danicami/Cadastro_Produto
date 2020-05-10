using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovimentosManuais.Models;

namespace MovimentosInfraestrutura.Mapeamento
{
    class ProdutoCosifMapa : IEntityTypeConfiguration<ProdutoCosif>
    {
        public void Configure(EntityTypeBuilder<ProdutoCosif> builder)
        {
            builder.ToTable("PRODUTO_COSIF");

            builder.HasKey(c => c.CodigoProduto)
                .HasName("COD_PRODUTO");

            builder.Property(c => c.CodigoProduto)
                .IsRequired()
                .HasColumnName("COD_PRODUTO");

            builder.Property(c => c.CodigoCosif)
                .IsRequired()
                .HasColumnName("COD_COSIF");

            builder.Property(c => c.CodigoClassificacao)
                .HasColumnName("COD_CLASSIFICACAO");

            builder.Property(c => c.Status)
                .HasColumnName("STA_STATUS");
        }

    }
}
