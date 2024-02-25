namespace ApiProduto.Domain
{
    public class Marca
    {
        protected Marca() { }
        public Marca(string descriscao,StatusMarcaEnum status) 
        {
            if (descriscao.Length <= 3 || descriscao.Length >= 100)
               new DomainException("A descrição deve conter mais de 3 e menos 100 caracteres!");
            if (status == null)
                new DomainException("O Status não pode ser vazio.");

            Descriscao = descriscao;
            Status = status;
        }

        public int Id { get; }
        public string Descriscao { get; private set; }
        public StatusMarcaEnum Status { get; private set; }
    }
}
