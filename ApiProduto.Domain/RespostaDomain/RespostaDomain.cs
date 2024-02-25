using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProduto.Domain
{
    public class RespostaDomain<TViwerModel>
    {
        public TViwerModel Dados { get; set; }
        public bool Erro { get; set; }
        public List<string> MensagemErro { get; set; }
    }
}
