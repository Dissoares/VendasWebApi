
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public  class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Pedido>().ToTable("Pedidos");
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            base.OnModelCreating(modelBuilder);
        }

    }
}
