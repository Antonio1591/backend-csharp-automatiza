using ApiProduto.Domain;

namespace ApiProduto.Aplicattion
{
    public static class MarcaMapping
    {
        public static MarcaViewModel ParaViewModel(this Marca marca)
        {
            return new MarcaViewModel
            {
                Id=marca.Id,
                Descricao=marca.Descricao,
                Status=marca.Status,
            };
        }
    }
}
