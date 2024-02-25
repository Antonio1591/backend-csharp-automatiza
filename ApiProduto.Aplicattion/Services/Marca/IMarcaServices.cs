using ApiProduto.Aplicattion.Model;
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
        public Task<RespostaApi<MarcaViewModel>> ListarMarcas();
        public Task<RespostaApi<MarcaViewModel>> BuscarMarcaId();
        public Task<RespostaApi<bool>> AtualizarMarca(MarcaInputModel inputModel);
        public RespostaApi<bool> Delete(MarcaInputModel inputModel);
    }
}
