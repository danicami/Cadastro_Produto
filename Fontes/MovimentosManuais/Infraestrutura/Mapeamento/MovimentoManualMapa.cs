using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovimentosManuais.Models;

namespace MovimentosInfraestrutura.Mapeamento
{
    class MovimentoManualMapa
    {
        public void Configure(EntityTypeBuilder<MovimentoManual> builder)
        {
            builder.ToTable("MOVIMENTO_MANUAL");

            builder.HasKey(c => c.CodigoProduto)
                .HasName("COD_PRODUTO");

            builder.Property(c => c.DataMes)
                .IsRequired()
                .HasColumnName("DAT_MES");

            builder.Property(c => c.DataAno)
                .IsRequired()
                .HasColumnName("DAT_ANO");

            builder.Property(c => c.NumeroLancamento)
                .IsRequired()
                .HasColumnName("NUM_LANCAMENTO");

            builder.Property(c => c.CodigoProduto)
               .IsRequired()
               .HasColumnName("COD_PRODUTO");

            builder.Property(c => c.CodigoCosif)
                .IsRequired()
               .HasColumnName("COD_COSIF");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnName("DES_DESCRICAO");

            builder.Property(c => c.DataLancamento)
              .IsRequired()
              .HasColumnName("DAT_MOVIMENTO");

            builder.Property(c => c.CodigoUsuario)
              .IsRequired()
              .HasColumnName("COD_USUARIO");

            builder.Property(c => c.Valor)
              .IsRequired()
              .HasColumnName("VAL_VALOR");



        }


    }
}
