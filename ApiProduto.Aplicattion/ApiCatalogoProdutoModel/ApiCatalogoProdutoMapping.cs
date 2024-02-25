using ApiProduto.Domain;

namespace ApiProduto.Aplicattion
{
    public static class ApiCatalogoProdutoMapping
    {
        public static ApiCatalogoProdutoViewModel ParaViewModel(this ApiCatalagoProduto apiCatalogoProduto)
        {
            return new ApiCatalogoProdutoViewModel
            {
               UrlImagem=apiCatalogoProduto.Imagens
            };
        }
    }
}
