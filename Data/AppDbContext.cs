using Microsoft.EntityFrameworkCore;
using MeuProjetoBackend.Models;

namespace MeuProjetoBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Produto>()
                .HasIndex(p => p.Nome)
                .IsUnique();

                modelBuilder.Entity<Produto>()
        .Property(p => p.Preco)
        .HasColumnType("decimal(18,2)");
        }
    }
}
