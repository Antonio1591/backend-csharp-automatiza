using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProduto.Domain.InputDomain.Produto
{
    public class ProdutoInputDomain
    {
        public int Id { get; set; }
        public string Descricao { get;set; }
        public decimal PrecoVenda { get;set; }
        public Marca Marca { get;set; }
        public int Estoque { get;set; }
        public StatusProdutoEnum Status { get;set; }
    }
}
