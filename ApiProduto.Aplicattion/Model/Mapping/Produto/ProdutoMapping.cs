using ApiProduto.Domain;

namespace ApiProduto.Aplicattion
{
    public static class ProdutoMapping
    {
        public static ProdutoViewModel ParaViewModel(this Produto produto)
        {
            return new ProdutoViewModel
            {
                Id = produto.Id,
                Descricao = produto.Descricao,
                MarcaId=produto.Marca.Id,
                DescricaoMarca = produto.Marca.Descricao,
                PrecoVenda = produto.PrecoVenda,
                Estoque = produto.Estoque,
                ValorEstoque = ((decimal)(produto.Estoque * produto.PrecoVenda)),
                Status = produto.Status,
            };
        }
    }
}
