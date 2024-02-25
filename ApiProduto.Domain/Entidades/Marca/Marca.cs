namespace ApiProduto.Domain
{
    public class Marca
    {
        protected Marca() { }
        public Marca(string descriscao, StatusMarcaEnum status)
        {
            ValidarDados(descriscao, status);

            Descriscao = descriscao;
            Status = status;
        }

        public int Id { get; set; }
        public string Descriscao { get; private set; }
        public StatusMarcaEnum Status { get; private set; }

        private void ValidarDados(string descriscao, StatusMarcaEnum status)
        {
            if (descriscao.Length <= 3 || descriscao.Length >= 100)
                new DomainException("A descrição deve conter mais de 3 e menos 100 caracteres!");
            if (status == null)
                new DomainException("O Status não pode ser vazio.");
        }

        public bool AtualizarMarca(int id, string descriscao, StatusMarcaEnum status)
        {
            ValidarDados(descriscao, status);
            if (id <= 0)
                new DomainException("Digite um id valido");
           
            Descriscao = descriscao;
            Status = status;
            return true;
        }

        public bool DeletarMarca()
        {
            Status = StatusMarcaEnum.REMOVIDO;
            return true;
        }
    }
}
