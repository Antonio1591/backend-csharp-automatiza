using ApiProduto.Domain.InputDomain.Produto;

namespace ApiProduto.Domain
{
    public class ProdutoServicesDomain : IProdutoServicesDomain
    {
        public List<string> ErrosDeValidacao = new List<string>();
        public async Task<RespostaDomain<Produto>> AtualizarProduto(Produto Produto, ProdutoInputDomain inputDomain)
        {
            if (Produto == null )
            {
                return new RespostaDomain<Produto>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Produto não encontrado,verifique os dados novamente!" }
                };
            }
            if (inputDomain.Status == StatusProdutoEnum.REMOVIDO)
            {
                return new RespostaDomain<Produto>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Não e possivel atualizar um produto para o status de removido, favor verificar o status e tentar novamente!" }
                };
            }

            if (inputDomain.Marca == null || inputDomain.Marca.Status == StatusMarcaEnum.REMOVIDO)
            {
                return new RespostaDomain<Produto>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Marca não encontrada ou marca deletada!" }
                };
            }

            var dadosProdutoDomain = ValidarDados(inputDomain.Descricao, inputDomain.PrecoVenda, inputDomain.Marca, inputDomain.Estoque, inputDomain.Status);
            if (!dadosProdutoDomain)
            {
                return new RespostaDomain<Produto>
                {
                    Erro = true,
                    MensagemErro = ErrosDeValidacao,
                };
            }

            Produto.AtualizarDados(inputDomain.Descricao,inputDomain.PrecoVenda,inputDomain.Marca,inputDomain.Estoque,inputDomain.Status);

            return new RespostaDomain<Produto>
            {
                Erro = false,
                Dados = Produto,

            };
        }


        public async Task<RespostaDomain<Produto>> CadastrarProduto(ProdutoInputDomain inputDomain)
        {
            if (inputDomain.Status == StatusProdutoEnum.REMOVIDO)
            {
                return new RespostaDomain<Produto>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Não e possivel adicionar um produto comm o status de removido!" }
                };
            }
            if (inputDomain.Marca == null || inputDomain.Marca.Status == StatusMarcaEnum.REMOVIDO)
            {
                return new RespostaDomain<Produto>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Marca não encontrada ou marca deletada!" }
                };
            }
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
                ErrosDeValidacao.Add("A descrição do produto deve conter mais de 3 e menos 300 caracteres!");
            if (precovenda < 0)
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
