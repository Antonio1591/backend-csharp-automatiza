using ApiProduto.Infrastructure.ApiCatalogo;

namespace ApiProduto.Infrastructure
{
    public class ApiCatalogoProdutoRepository : IApiCatalogoProdutoRepository
    {
        private readonly HttpClient _httpClient;
        public ApiCatalogoProdutoRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> BuscarImagem(string codigoBarras)
        {
            try
            {
                var url = $"https://catalogoautomatiza.azurewebsites.net/api/produtos/{codigoBarras}";
                return await _httpClient.GetAsync(url);
                
            }
            catch (Exception ex)
            {
                throw new ApiCatalagoException(ex.Message) ;
            }
        }
    }
}

