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
            var url = $"https://catalogoautomatiza.azurewebsites.net/api/produtos/{codigoBarras}";
           return await _httpClient.GetAsync(url);
        }

        //public async Task<ApiCatalagoProduto> BuscarImagem(string codigoBarras)
        //{
        //    var url = $"https://catalogoautomatiza.azurewebsites.net/api/produtos/{codigoBarras}";
        //    var response = await _httpClient.GetAsync(url);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new HttpRequestException($"Erro ao buscar imagem: {response.StatusCode}");
        //    }

        //    var content = await response.Content.ReadAsStringAsync();
        //    var apiCatalagoProduto = JsonConvert.DeserializeObject<ApiCatalagoProduto>(content);

        //    return apiCatalagoProduto;
        //}
    }
}

