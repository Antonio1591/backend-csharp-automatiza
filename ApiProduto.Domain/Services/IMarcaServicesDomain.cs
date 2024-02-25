namespace ApiProduto.Domain
{
    public interface IMarcaServicesDomain
    {
        public Task<RespostaDomain<Marca>> CadastrarMarca(MarcaInputDomain inputDomain);
        public RespostaDomain<Marca> AtualizarMarca(MarcaInputDomain inputDomain);
        public RespostaDomain<Marca> Delete(MarcaInputDomain inputDomain);
      
    }
}
