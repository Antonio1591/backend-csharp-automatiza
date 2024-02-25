using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
