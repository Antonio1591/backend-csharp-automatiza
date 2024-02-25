using ApiProduto.Domain;
using System.ComponentModel;

namespace ApiProduto.Domain
{
    public class MarcaServicesDomain : IMarcaServicesDomain
    {

        public List<string> ErrosDeValidacao = new List<string>();
        public RespostaDomain<Marca> AtualizarMarca(MarcaInputDomain inputDomain)
        {
            throw new NotImplementedException();
        }


        public async Task<RespostaDomain<Marca>> CadastrarMarca(MarcaInputDomain inputDomain)
        {
           var dadosValidos=  ValidarDados(inputDomain.Descriscao,inputDomain.Status);
            if(!dadosValidos)
            {
                return new RespostaDomain<Marca>
                {
                    Erro = true,
                    MensagemErro = ErrosDeValidacao,
                };
            }

            var marcadomain =  new Marca(inputDomain.Descriscao,inputDomain.Status);

            return new RespostaDomain<Marca>
            { 
               Erro=false,
               Dados=marcadomain,
                   
            };
            
        }

        public RespostaDomain<Marca> Delete(MarcaInputDomain inputDomain)
        {
            throw new NotImplementedException();
        }

        private  bool ValidarDados(string descriscao,StatusMarcaEnum status)
        {
            if(descriscao.Length <=3 || descriscao.Length >=100)
                ErrosDeValidacao.Add("A descrição deve conter mais de 3 e menos 100 caracteres!");
            if (status == null )
                ErrosDeValidacao.Add("O Status não pode ser vazio.");

            return  !ErrosDeValidacao.Any() ? true : false;
        }
       
    }
}
