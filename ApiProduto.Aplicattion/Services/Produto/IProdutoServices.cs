using ApiProduto.Aplicattion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProduto.Aplicattion
{
    public interface IProdutoServices
    {
        public Task<RespostaApi<bool>> CadastrarProduto(ProdutoInputModel inputModel);
        public Task<RespostaApi<IEnumerable<ProdutoViewModel>>> ListarProdutos();
        public Task<RespostaApi<ProdutoViewModel>> BuscarProdutoId(int id);
        public Task<RespostaApi<bool>> AtualizarProduto(ProdutoInputModel inputModel);
        public Task<RespostaApi<bool>> DeletarProduto(int id);
    }
}
