using ApiProduto.Aplicattion.Model;
using ApiProduto.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProduto.Aplicattion.Services
{
    public interface IMarcaServices
    {
        public Task<RespostaApi<bool>> CadastrarMarca(MarcaInputModel inputModel);
        public Task<RespostaApi<IEnumerable<MarcaViewModel>>> ListarMarcas();
        public Task<RespostaApi<MarcaViewModel>> BuscarMarcaId(int id);
        public Task<RespostaApi<bool>> AtualizarMarca(MarcaInputModel inputModel);
        public Task<RespostaApi<bool>> DeletarMarca(int id);
    }
}
