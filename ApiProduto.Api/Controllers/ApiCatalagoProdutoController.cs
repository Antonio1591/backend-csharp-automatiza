using ApiProduto.Aplicattion;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduto.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ApiCatalagoProdutoController : ControllerBase
    {
        private readonly IApiCatalogoProdutoServices _apiCatalogoProduto;

        public ApiCatalagoProdutoController(IApiCatalogoProdutoServices apiCatalogoProduto)
        {
            _apiCatalogoProduto = apiCatalogoProduto;
        }

        [HttpGet("{ean}/imagens")]
        public async Task<ActionResult<RespostaApi<ApiCatalogoProdutoViewModel>>> BuscarProdutoId(string ean)
        {
            var buscarprodutoid = await _apiCatalogoProduto.BuscarImagem(ean);
           
            if (buscarprodutoid.Erro)
                return BadRequest(buscarprodutoid);
            return Ok(buscarprodutoid);

        }
    }
}
