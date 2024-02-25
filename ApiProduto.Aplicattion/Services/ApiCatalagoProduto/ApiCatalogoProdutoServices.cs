using ApiProduto.Domain;
using ApiProduto.Infrastructure;
using Newtonsoft.Json;

namespace ApiProduto.Aplicattion
{
    public class ApiCatalogoProdutoServices : IApiCatalogoProdutoServices
    {
       private readonly IApiCatalogoProdutoRepository _ApiCatalogoProdutoRepository;

        public ApiCatalogoProdutoServices(IApiCatalogoProdutoRepository repository)
        {
            _ApiCatalogoProdutoRepository = repository;
        }

        public async Task<RespostaApi<ApiCatalogoProdutoViewModel>> BuscarImagem(string codigoBarras)
        {
            var response= await _ApiCatalogoProdutoRepository.BuscarImagem(codigoBarras);

            if (!response.IsSuccessStatusCode)
            {
                return new RespostaApi<ApiCatalogoProdutoViewModel>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Erro ao buscar imagem,verifique o codigo de barras!" }
                };
            }

            var content = await response.Content.ReadAsStringAsync();
            var apiCatalagoProduto = JsonConvert.DeserializeObject<ApiCatalagoProduto>(content);

            return new RespostaApi<ApiCatalogoProdutoViewModel>
            {   Erro=false,
                Dados = apiCatalagoProduto.ParaViewModel()
            };
        }
    }
}
