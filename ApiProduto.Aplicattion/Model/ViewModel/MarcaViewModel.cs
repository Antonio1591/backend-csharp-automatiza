using ApiProduto.Domain;

namespace ApiProduto.Aplicattion.Model
{
    public class MarcaViewModel
    {
        public int Id { get; set; }
        public string Descriscao { get;  set; }
        public StatusMarcaEnum Status { get;  set; }
    }
}
