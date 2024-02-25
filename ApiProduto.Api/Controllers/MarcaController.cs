using ApiProduto.Aplicattion.Model;
using ApiProduto.Aplicattion.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiProduto.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaServices _marcaServices;

        public MarcaController(IMarcaServices marcaServices)
        {
            _marcaServices = marcaServices;
        }

        [HttpPost]
        public async Task<ActionResult<RespostaApi<bool>>> CadastrarMarca(MarcaInputModel inputModel)
        {
            var marcacadastrada = _marcaServices.CadastrarMarca(inputModel);

            if (marcacadastrada.Result.Erro)
            {
                return  BadRequest(marcacadastrada.Result);
            }

            return Ok(marcacadastrada.Result);
        }
        //[HttpGet]
        //public ActionResult<Task<RespostaApi<MarcaViewModel>>> BuscarMarcaId(int id)
        //{
        //}

        //[HttpGet]
        //public ActionResult<Task<RespostaApi<List<MarcaViewModel>>>> ListarMarcas()
        //{
        //}

        //[HttpPut]
        //public ActionResult<Task<RespostaApi<bool>>> AtualizarMarca(MarcaInputModel inputModel)
        //{

        //}

        //[HttpDelete]
        //public ActionResult<RespostaApi<bool>> Delete(int id)
        //{ }

    }
}


//POST / api / marcas: cadastrar uma nova marca.
//        GET /api/marcas: listar todas as marcas.
//    GET /api/marcas/{ id}: Retorna os detalhes de uma marca específica pelo id.
//    PUT /api/marcas/{id
//    }: Atualiza os dados de uma marca existente.
//    DELETE /api/marcas/{id
//}: Remove uma marca do sistema.