using Microsoft.EntityFrameworkCore;
using RestauranteNascimento.Models;

namespace RestauranteNascimento.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
