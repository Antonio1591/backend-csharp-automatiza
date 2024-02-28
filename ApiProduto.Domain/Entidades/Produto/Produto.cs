using System.Text.RegularExpressions;

namespace ApiProduto.Domain
{
    public class Produto
    {
        protected Produto() { }
        public Produto(string descricao, decimal precoVenda, Marca marca, int estoque, StatusProdutoEnum status)
        {
            ValidarDados(descricao, precoVenda, marca, estoque, status);
            if (status == StatusProdutoEnum.REMOVIDO)
                throw new DomainException("Não e possivel cadastrar uma Produto com o status de removida, favor verificar o status e tentar novamente!");
            if (marca == null || marca.Status == StatusMarcaEnum.REMOVIDO)
                throw new DomainException("Marca não encontrada ou marca deletada!");
            Descricao = descricao;
            PrecoVenda = precoVenda;
            Marca = marca;
            Estoque = estoque;
            Status = status;
        }
        public int Id { get; set; }
        public string Descricao { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public Marca Marca { get; private set; }
        public int Estoque { get; private set; }
        public StatusProdutoEnum Status { get; private set; }

        public bool AtualizarDados(string descricao, decimal precoVenda, Marca marca, int estoque, StatusProdutoEnum status)
        {
            ValidarDados(descricao, precoVenda, marca, estoque, status);
            if (Id <= 0)
                throw new DomainException("Digite um id valido");
            if (status == StatusProdutoEnum.REMOVIDO)
                throw new DomainException("Não e possivel atualizar um produto para o status de removido, favor verificar o status e tentar novamente!");
            if (marca == null || marca.Status == StatusMarcaEnum.REMOVIDO)
                throw new DomainException("Marca não encontrada ou marca deletada!");

            bool descricaoalterada = Descricao != descricao;
            bool precovendaalterado = PrecoVenda != precoVenda;
            bool marcaalterada = !object.Equals(Marca, marca);
            bool estoquealterado = Estoque != estoque;
            bool statusalterado = Status != status;
            if (!descricaoalterada && !precovendaalterado && !marcaalterada && !estoquealterado && !statusalterado)
                throw new DomainException("Nenhuma informação do produto Alterada!");

            if (descricaoalterada)
                Descricao = descricao;
            if (precovendaalterado)
                PrecoVenda = precoVenda;
            if (marcaalterada)
                Marca = marca;
            if (estoquealterado)
                Estoque = estoque;
            if (statusalterado)
                Status = status;
            return true;

        }
        public bool DeletarProduto()
        {
            if (Id <= 0)
                throw new DomainException("Digite um id valido,para continuar com a exclusão");
            Status = StatusProdutoEnum.REMOVIDO;
            return true;
        }
        private void ValidarDados(string descricao, decimal precovenda, Marca marca, int estoque, StatusProdutoEnum status)
        {
            if (descricao.Length <= 3 || descricao.Length >= 300)
                throw new DomainException("A descrição do produto deve conter mais de 3 e menos 300 caracteres!");
            if (precovenda < 0)
                throw new DomainException("O Preço de venda não pode ser negativo ou zerado. Verifique o preço de venda!");
            if (marca == null)
                throw new DomainException("Marca Não informada ou Invalida.");
            if (estoque < 0)
                throw new DomainException("O Estoque não pode ser menor que zero !");
            if (!Enum.IsDefined(typeof(StatusProdutoEnum), status))
                throw new DomainException("O Status do produto não e valido!.");

        }

    }
}
