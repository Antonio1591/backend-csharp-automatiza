using ApiProduto.Domain;

namespace ApiProduto.Aplicattion
{
    public class MarcaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get;  set; }
        public StatusMarcaEnum Status { get;  set; }
    }
}
