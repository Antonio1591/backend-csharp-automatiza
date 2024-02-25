namespace ApiProduto.Domain
{
    public interface IMarcaServicesDomain
    {
        public Task<RespostaDomain<Marca>> CadastrarMarca(MarcaInputDomain inputDomain);
        public Task<RespostaDomain<Marca>> AtualizarMarca(Marca marca, string descriscaoAlterar, StatusMarcaEnum StatusAlterar);
        public Task<RespostaDomain<Marca>> DeletarMarca(Marca marca);
      
    }
}
