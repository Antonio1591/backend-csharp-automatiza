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

        [HttpPost]
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

        [HttpGet]
        public async Task<ActionResult<RespostaApi<IEnumerable<MarcaViewModel>>>> ListarMarcas()
        {
            var buscarMarcaId = await _marcaServices.ListarMarcas();

            if (buscarMarcaId.Erro)
                return BadRequest(buscarMarcaId);
            return Ok(buscarMarcaId);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<RespostaApi<bool>>> AtualizarMarca(int id,MarcaInputModel inputModel)
        {
            var marcacadastrada =  await _marcaServices.AtualizarMarca(id,inputModel);

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