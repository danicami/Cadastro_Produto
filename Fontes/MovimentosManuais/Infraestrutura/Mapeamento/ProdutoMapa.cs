using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovimentosManuais.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovimentosInfraestrutura.Mapeamento
{
    public class ProdutoMapa : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");

            builder.HasKey(c => c.CodigoProduto)
                .HasName("COD_PRODUTO");

            builder.Property(c => c.CodigoProduto)
                .IsRequired()
                .HasColumnName("COD_PRODUTO");

            builder.Property(c => c.DescricaoProduto)
                .IsRequired()
                .HasColumnName("DES_PRODUTO");

            builder.Property(c => c.Status)
                .IsRequired()
                .HasColumnName("STA_STATUS");
        }
    }
}