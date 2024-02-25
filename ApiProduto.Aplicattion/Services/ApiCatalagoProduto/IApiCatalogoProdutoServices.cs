using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProduto.Aplicattion
{

    public interface IApiCatalogoProdutoServices
    {
        public Task<RespostaApi<ApiCatalogoProdutoViewModel>> BuscarImagem(string codigoBarras);
    }
}
