using ControleEstoqueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoqueAPI.Context
{
    public class EstoqueContext : DbContext
    {
        protected EstoqueContext()
        {
        }

        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
