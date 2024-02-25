using ApiProduto.Domain;

namespace ApiProduto.Infrastructure
{
    public interface IProdutoRepository
    {
        public Task<bool> CadastrarProduto(Produto produto);

        public Task<IEnumerable<Produto>> ListarProdutos();

        public Task<Produto> BuscarProdutoId(int id);

        public Task<bool> AtualizarProduto(Produto produto);

        public Task<bool> DeletarProduto(Produto produto);
    }
}

