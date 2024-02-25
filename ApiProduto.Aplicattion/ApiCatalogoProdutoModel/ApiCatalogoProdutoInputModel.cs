using System.Text.Json.Serialization;

namespace ApiProduto.Aplicattion
{
    public class ApiCatalogoProdutoInputModel
    {
        public string Descricao { get; set; }
        public string CodigoBarras { get; set; }
        public string urlImagem { get; set; }
    }
}
