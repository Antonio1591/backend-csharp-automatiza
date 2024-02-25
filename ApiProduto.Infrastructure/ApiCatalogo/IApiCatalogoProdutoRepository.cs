using ApiProduto.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProduto.Infrastructure
{
    public interface IApiCatalogoProdutoRepository
    {
        public Task<HttpResponseMessage> BuscarImagem(string codigoBarras);
    }
}

