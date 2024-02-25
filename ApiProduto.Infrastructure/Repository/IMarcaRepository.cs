using ApiProduto.Domain;

namespace ApiProduto.Infrastructure
{
    public interface IMarcaRepository
    {
        public Task<bool> CadastrarMarca(Marca marca);

        public Task<List<Marca>> ListarMarcas();

        public Task<Marca> BuscarMarcaId(int id);

        public Task<bool> AtualizarMarca(Marca marca);

        public Task<bool> DeletarMarca(Marca marca);
    }
}

