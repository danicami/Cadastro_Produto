using Microsoft.EntityFrameworkCore;
using MovimentosInfraestrutura.Mapeamento;
using MovimentosManuais.Models;

namespace MovimentosInfraestrutura.Contexto
{
    public class ContextoAplicacao : DbContext
    {

        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoCosif> ProdutoCosif { get; set; }
        public DbSet<MovimentoManual> MovimentoManual { get; set; }
        public DbQuery<MovimentoManualProduto> MovimentoManualProduto { get; set; }

        public ContextoAplicacao(DbContextOptions<ContextoAplicacao> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseSqlServer (@"Server=(localdb)\mssqllocaldb;Database=Cliente;Trusted_Connection=True;ConnectRetryCount=0");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>(new ProdutoMapa().Configure);
            modelBuilder.Entity<ProdutoCosif>(new ProdutoCosifMapa().Configure);
            modelBuilder.Entity<MovimentoManual>(new MovimentoManualMapa().Configure);
            modelBuilder.Query<MovimentoManualProduto>();
   
        }

    }
}
