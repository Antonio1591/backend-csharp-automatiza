using System.Text.Json.Serialization;

namespace ApiProduto.Domain
{
    public class ApiCatalagoProduto
    {
        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("codigoBarras")]
        public string CodigoBarras { get; set;}

        [JsonPropertyName("imagens")]
        public List<string> Imagens {  get; set;}
    }
    
}
