using ApiProduto.Aplicattion;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduto.Api.Controllers
{
        [ApiController]
        [Route("Api/[controller]")]
        public class ProdutosController : ControllerBase
        {
            private readonly IProdutoServices _ProdutoServices;
            
        public ProdutosController(IProdutoServices produtoServices)
        {
            _ProdutoServices = produtoServices;
        }

        [HttpPost]
            public async Task<ActionResult<RespostaApi<bool>>> CadastrarProduto(ProdutoInputModel inputModel)
            {
                var produtocadastrado = await _ProdutoServices.CadastrarProduto(inputModel);

                if (produtocadastrado.Erro)
                    return BadRequest(produtocadastrado);


                return Ok(produtocadastrado);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<RespostaApi<ProdutoViewModel>>> BuscarProdutoId(int id)
            {
                var buscarprodutoid = await _ProdutoServices.BuscarProdutoId(id);

                if (buscarprodutoid.Erro)
                    return BadRequest(buscarprodutoid);
                return Ok(buscarprodutoid);

            }

            [HttpGet]
            public async Task<ActionResult<RespostaApi<IEnumerable<ProdutoViewModel>>>> ListarProdutos()
            {
                var buscarprodutoid = await _ProdutoServices.ListarProdutos();

                if (buscarprodutoid.Erro)
                    return BadRequest(buscarprodutoid);
                return Ok(buscarprodutoid);

            }


            [HttpPut("{id}")]
            public async Task<ActionResult<RespostaApi<bool>>> AtualizarProduto(int id,ProdutoInputModel inputModel)
            {
                var produtocadastrada = await _ProdutoServices.AtualizarProduto(id, inputModel);

                if (produtocadastrada.Erro)
                    return BadRequest(produtocadastrada);


                return Ok(produtocadastrada);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<RespostaApi<bool>>> Delete(int id)
            {
                var deletarproduto = await _ProdutoServices.DeletarProduto(id);

                if (deletarproduto.Erro)
                    return BadRequest(deletarproduto);


                return Ok(deletarproduto);
            }

        }
    }


