using ApiProduto.Domain.InputDomain.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProduto.Domain
{
    public interface IProdutoServicesDomain
    {
        public Task<RespostaDomain<Produto>> CadastrarProduto(ProdutoInputDomain inputDomain);
        public Task<RespostaDomain<Produto>> AtualizarProduto(Produto Produto, ProdutoInputDomain inputDomain);
        public Task<RespostaDomain<Produto>> DeletarProduto(Produto Produto);
    }
}
