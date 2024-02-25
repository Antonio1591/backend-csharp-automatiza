using ApiProduto.Aplicattion.Model;
using ApiProduto.Domain;
using ApiProduto.Infrastructure;

namespace ApiProduto.Aplicattion.Services
{
    public class MarcaServices : IMarcaServices
    {
        private readonly IMarcaServicesDomain _marcaService;
        private readonly IMarcaRepository _marcaRepository;
        public MarcaServices(IMarcaServicesDomain marcaService, IMarcaRepository marcaRepository)
        {
            _marcaService = marcaService;
            _marcaRepository = marcaRepository;
        }

        public Task<RespostaApi<bool>> AtualizarMarca(MarcaInputModel inputModel)
        {
            throw new NotImplementedException();
        }


        public async Task<RespostaApi<bool>> CadastrarMarca(MarcaInputModel inputModel)
        {
            var inputdomain = new MarcaInputDomain { Descriscao = inputModel.Descriscao, Status = inputModel.Status = default };

            var marca = _marcaService.CadastrarMarca(inputdomain);

            if (marca.Result.Erro)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = marca.Result.MensagemErro
                };
            }
            var retornoBanco = _marcaRepository.CadastrarMarca(marca.Result.Dados);

            return new RespostaApi<bool>
            {
                Dados = retornoBanco.Result,

            };
        }

        public RespostaApi<bool> Delete(MarcaInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaApi<MarcaViewModel>> ListarMarcas()
        { throw new NotImplementedException(); }

        public Task<RespostaApi<MarcaViewModel>> BuscarMarcaId()
        { throw new NotImplementedException(); }

       

    }
}
