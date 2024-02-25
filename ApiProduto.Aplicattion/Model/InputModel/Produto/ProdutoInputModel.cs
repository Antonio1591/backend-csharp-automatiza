using ApiProduto.Domain;

namespace ApiProduto.Aplicattion
{
    public class ProdutoInputModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public Marca Marca { get; set; }
        public int Estoque { get; set; }
        public StatusProdutoEnum Status { get; set; }
    }
}
