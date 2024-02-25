using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProduto.Aplicattion.Model
{
    public class RespostaApi<TViwerModel>
    {
        public TViwerModel Dados { get; set; }
        public bool Erro { get; set; }
        public List<string> MensagemErro { get; set; }
    }
}
