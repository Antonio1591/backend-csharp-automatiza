using ApiProduto.Domain.InputDomain.Produto;

namespace ApiProduto.Domain
{
    public class ProdutoServicesDomain : IProdutoServicesDomain
    {
        public List<string> ErrosDeValidacao = new List<string>();
        public async Task<RespostaDomain<Produto>> AtualizarProduto(Produto Produto, ProdutoInputDomain inputDomain)
        {
            //Colocado para validar apenas o Input, pois devido fazer a busca antes da entidade Produto, entedesse que esta correto os dados,
            //e caso de algum erro de importação de dados com o atualizar o cliente vai conseguir informar os dados validos

            var dadosProdutoDomain = ValidarDados(inputDomain.Descricao, inputDomain.PrecoVenda, inputDomain.Marca, inputDomain.Estoque, inputDomain.Status);
            if (!dadosProdutoDomain)
            {
                return new RespostaDomain<Produto>
                {
                    Erro = true,
                    MensagemErro = ErrosDeValidacao,
                };
            }

            Produto.AtualizarDados( inputDomain.Id,inputDomain.Descricao,inputDomain.PrecoVenda,inputDomain.Marca,inputDomain.Estoque,inputDomain.Status);

            return new RespostaDomain<Produto>
            {
                Erro = false,
                Dados = Produto,

            };
        }


        public async Task<RespostaDomain<Produto>> CadastrarProduto(ProdutoInputDomain inputDomain)
        {
           var dadosvalidos= ValidarDados(inputDomain.Descricao, inputDomain.PrecoVenda, inputDomain.Marca, inputDomain.Estoque, inputDomain.Status);
            if (!dadosvalidos)
            {
                return new RespostaDomain<Produto>
                {
                    Erro = true,
                    MensagemErro = ErrosDeValidacao,
                };
            }

            var Produtodomain = new Produto(inputDomain.Descricao,inputDomain.PrecoVenda,inputDomain.Marca,inputDomain.Estoque,inputDomain.Status);

            return new RespostaDomain<Produto>
            {
                Erro = false,
                Dados = Produtodomain,

            };

        }

        public async Task<RespostaDomain<Produto>> DeletarProduto(Produto Produto)
        {
            Produto.DeletarProduto();

            return new RespostaDomain<Produto>
            {
                Erro = false,
                Dados = Produto,
            };
        }

        private bool ValidarDados(string descricao, decimal precovenda,Marca marca,int estoque,StatusProdutoEnum status)
        {
            if (descricao.Length <= 3 || descricao.Length >= 300)
                ErrosDeValidacao.Add("A descrição deve conter mais de 3 e menos 300 caracteres!");
            if (precovenda <= 0)
                ErrosDeValidacao.Add("O Preço de venda não pode ser negativo ou zerado. Verifique o preço de venda!");
            if (marca == null)
                ErrosDeValidacao.Add("Marca Não informada ou Invalida.");
            if (estoque < 0)
                ErrosDeValidacao.Add("O Estoque não pode ser menor que zero !");
            if (!Enum.IsDefined(typeof(StatusProdutoEnum), status))
                ErrosDeValidacao.Add("O Status do produto não é válido.");
            return !ErrosDeValidacao.Any() ? true : false;
        }
    }
}
