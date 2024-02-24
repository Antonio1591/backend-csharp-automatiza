using ApiProduto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiProduto.Api.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void CofinguracaoConexaoBancoDeDados(this IServiceCollection builder, IConfiguration configuration)
        {
            string stringConexao = configuration.GetConnectionString("conexaoMysql");

            builder.AddDbContext<DataContext>(opt =>
            opt.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao)).UseSnakeCaseNamingConvention());
        }

        
    }
}
