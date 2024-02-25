using System.Text.RegularExpressions;

namespace ApiProduto.Domain
{
    public class Marca
    {
        protected Marca() { }
        public Marca(string descricao, StatusMarcaEnum status)
        {
            ValidarDados(descricao, status);

            Descricao = descricao;
            Status = status;
        }

        public int Id { get; set; }
        public string Descricao { get; private set; }
        public StatusMarcaEnum Status { get; private set; }

        private void ValidarDados(string descricao, StatusMarcaEnum status)
        {
            if (descricao.Length <= 3 || descricao.Length >= 100)
                throw new DomainException("A descrição deve conter mais de 3 e menos 100 caracteres!");
            if (!Enum.IsDefined(typeof(StatusMarcaEnum), status))
                throw new DomainException("O Status da marca não é válido.");
        }

        public bool AtualizarMarca(int id, string descricao, StatusMarcaEnum status)
        {
            ValidarDados(descricao, status);
            if (id <= 0)
                throw new DomainException("Digite um id valido");

            bool descricaoalterada = Descricao != descricao;
            bool statusalterado = Status != status;
            if (!descricaoalterada &&  !statusalterado)
                throw new DomainException("Nenhuma informação do produto Alterada!");

            if (descricaoalterada)
                Descricao = descricao;
            if (statusalterado)
                Status = status;
            return true;
          
        }

        public bool DeletarMarca()
        {
            if (Id <= 0)
                throw new DomainException("Digite um id valido,para continuar com a exclusão");
            Status = StatusMarcaEnum.REMOVIDO;
            return true;
        }
    }
}
