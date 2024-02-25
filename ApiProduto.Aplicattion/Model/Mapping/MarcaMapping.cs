using ApiProduto.Domain;

namespace ApiProduto.Aplicattion.Model
{
    public static class MarcaMapping
    {
        public static MarcaViewModel ParaViewModel(this Marca marca)
        {
            return new MarcaViewModel
            {
                Id=marca.Id,
                Descriscao=marca.Descriscao,
                Status=marca.Status,
            };
        }
    }
}
