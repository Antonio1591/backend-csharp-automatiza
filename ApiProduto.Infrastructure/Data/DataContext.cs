using ApiProduto.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiProduto.Infrastructure.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Marca> Marcas { get; set; }
    }
}
