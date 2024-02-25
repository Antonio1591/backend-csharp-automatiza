using ApiProduto.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProduto.Aplicattion
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public int MarcaId { get; set; }
        public string DescricaoMarca { get; set; }
        public int Estoque { get; set; }
        public decimal ValorEstoque { get; set; }
        public StatusProdutoEnum Status { get; set; }
    }
}
