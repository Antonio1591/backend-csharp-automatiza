namespace ApiProduto.Domain
{
    public interface IMarcaServicesDomain
    {
        public Task<RespostaDomain<Marca>> CadastrarMarca(MarcaInputDomain inputDomain);
        public Task<RespostaDomain<Marca>> AtualizarMarca(Marca marca, MarcaInputDomain inputDomain);
        public Task<RespostaDomain<Marca>> DeletarMarca(Marca marca);
      
    }
}
