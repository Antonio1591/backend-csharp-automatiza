namespace ApiProduto.Domain.Entidades
{
    public class Produto
    {
        public int id { get; set; }
        public string Descriscao { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public Marca Marca { get; private set; }
        public int Estoque { get; private set; }
        public StatusProdutoEnum Status { get; private set; }
    }
}
