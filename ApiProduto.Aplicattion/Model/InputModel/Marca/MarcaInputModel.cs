using ApiProduto.Domain;

namespace ApiProduto.Aplicattion
{
    public class MarcaInputModel
    {
        public string Descricao { get;  set; }
        public StatusMarcaEnum Status { get;  set; }
    }
}
