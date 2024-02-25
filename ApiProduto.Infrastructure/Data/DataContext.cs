using ApiProduto.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiProduto.Infrastructure.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
