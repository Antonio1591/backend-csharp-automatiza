namespace ApiProduto.Domain.Entidades
{
    public class Marca
    {
        public int Id { get;  set; }
        public string Descriscao { get; private set; }
        public StatusMarcaEnum Status { get; private set; }
    }
}
