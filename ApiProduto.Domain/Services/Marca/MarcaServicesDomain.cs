using ApiProduto.Domain;
using System.ComponentModel;

namespace ApiProduto.Domain
{
    public class MarcaServicesDomain : IMarcaServicesDomain
    {

        public List<string> ErrosDeValidacao = new List<string>();
        public async Task<RespostaDomain<Marca>> AtualizarMarca(Marca marca,MarcaInputDomain inputDomain)
        {
            var dadosValidos = ValidarDados(inputDomain.Descricao,inputDomain.Status);
            if (!dadosValidos)
            {
                return new RespostaDomain<Marca>
                {
                    Erro = true,
                    MensagemErro = ErrosDeValidacao,
                };
            }
 
            marca.AtualizarMarca(inputDomain.Id,inputDomain.Descricao, inputDomain.Status);

            return new RespostaDomain<Marca>
            {
                Erro = false,
                Dados = marca,

            };
        }


        public async Task<RespostaDomain<Marca>> CadastrarMarca(MarcaInputDomain inputDomain)
        {
           var dadosValidos=  ValidarDados(inputDomain.Descricao,inputDomain.Status);
            if(!dadosValidos)
            {
                return new RespostaDomain<Marca>
                {
                    Erro = true,
                    MensagemErro = ErrosDeValidacao,
                };
            }

            var marcadomain =  new Marca(inputDomain.Descricao,inputDomain.Status);

            return new RespostaDomain<Marca>
            { 
               Erro=false,
               Dados=marcadomain,
                   
            };
            
        }

        public async Task<RespostaDomain<Marca>> DeletarMarca(Marca marca)
        {

            marca.DeletarMarca();

            return new RespostaDomain<Marca>
            {
                Erro = false,
                Dados = marca,
            };
        }

        private  bool ValidarDados(string Descricao,StatusMarcaEnum status)
        {
            if(Descricao.Length <=3 || Descricao.Length >=100)
                ErrosDeValidacao.Add("A descrição deve conter mais de 3 e menos 100 caracteres!");
            if (!Enum.IsDefined(typeof(StatusMarcaEnum), status))
                ErrosDeValidacao.Add("O Status da marca não e valido!.");

            return  !ErrosDeValidacao.Any() ? true : false;
        }
       
    }
}
