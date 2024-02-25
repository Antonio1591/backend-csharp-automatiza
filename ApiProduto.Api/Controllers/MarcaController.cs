using ApiProduto.Aplicattion;
using ApiProduto.Aplicattion.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduto.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public partial class MarcaController : ControllerBase
    {
        private readonly IMarcaServices _marcaServices;

        public MarcaController(IMarcaServices marcaServices)
        {
            _marcaServices = marcaServices;
        }

        [HttpPost("CadastrarMarca")]
        public async Task<ActionResult<RespostaApi<bool>>> CadastrarMarca(MarcaInputModel inputModel)
        {
            var marcacadastrada = await _marcaServices.CadastrarMarca(inputModel);

            if (marcacadastrada.Erro)
                return BadRequest(marcacadastrada);
            

            return Ok(marcacadastrada);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespostaApi<MarcaViewModel>>> BuscarMarcaId(int id)
        {
            var buscarMarcaId =await _marcaServices.BuscarMarcaId(id);

            if(buscarMarcaId.Erro)
                return BadRequest(buscarMarcaId);
            return Ok(buscarMarcaId);

        }

        [HttpGet("ListarMarcas")]
        public async Task<ActionResult<RespostaApi<IEnumerable<MarcaViewModel>>>> ListarMarcas()
        {
            var buscarMarcaId = await _marcaServices.ListarMarcas();

            if (buscarMarcaId.Erro)
                return BadRequest(buscarMarcaId);
            return Ok(buscarMarcaId);

        }


        [HttpPut("AtualizarMarca")]
        public async Task<ActionResult<RespostaApi<bool>>> AtualizarMarca(MarcaInputModel inputModel)
        {
            var marcacadastrada =  await _marcaServices.AtualizarMarca(inputModel);

            if (marcacadastrada.Erro)
                return BadRequest(marcacadastrada);


            return Ok(marcacadastrada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespostaApi<bool>>> Delete(int id)
        {
            var deletarmarca= await _marcaServices.DeletarMarca(id);

                 if (deletarmarca.Erro)
                return BadRequest(deletarmarca);

            return Ok(deletarmarca);
        }
    }

}


//POST / api / marcas: cadastrar uma nova marca.
//        GET /api/marcas: listar todas as marcas.
//    GET /api/marcas/{ id}: Retorna os detalhes de uma marca específica pelo id.
//    PUT /api/marcas/{id
//    }: Atualiza os dados de uma marca existente.
//    DELETE /api/marcas/{id
//}: Remove uma marca do sistema.