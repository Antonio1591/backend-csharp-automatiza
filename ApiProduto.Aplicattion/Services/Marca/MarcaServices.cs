using ApiProduto.Aplicattion;
using ApiProduto.Domain;
using ApiProduto.Domain.InputDomain.Produto;
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
        public async Task<RespostaApi<bool>> CadastrarMarca( MarcaInputModel inputModel)
        {
            if (inputModel.Status == StatusMarcaEnum.REMOVIDO)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Não e possivel cadastrar uma marca com o status de removida, favor verificar o status e tentar novamente" }
                };
            }
            var inputdomain = new MarcaInputDomain { Descricao = inputModel.Descricao, Status = inputModel.Status };

            var marca = await _marcaService.CadastrarMarca(inputdomain);

            if (marca.Erro)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = marca.MensagemErro
                };
            }
            var retornoBanco = _marcaRepository.CadastrarMarca(marca.Dados);

            return new RespostaApi<bool>
            {
                Dados = retornoBanco.Result,

            };
        }
        public async Task<RespostaApi<bool>> AtualizarMarca(int id,MarcaInputModel inputModel)
        {
            if (id <= 0)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Digite um Id Válido para continuar sua consulta." }
                };
            }
            var marcaalterar = await _marcaRepository.BuscarMarcaId(id);

            if (marcaalterar == null)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Marca não encontrada, verifique o Id!" },
                };
            }
            var inputdomain = new MarcaInputDomain {Descricao=inputModel.Descricao,Status=inputModel.Status };
            var marcaatualizada = await _marcaService.AtualizarMarca(marcaalterar,inputdomain) ;

            if (marcaatualizada.Erro)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = marcaatualizada.MensagemErro
                };
            }
            var retornoBanco = _marcaRepository.AtualizarMarca(marcaatualizada.Dados);

            return new RespostaApi<bool>
            {
                Dados = retornoBanco.Result,

            };
        }

        public async Task<RespostaApi<IEnumerable<MarcaViewModel>>> ListarMarcas()
        {
            var listamarcas = await _marcaRepository.ListarMarcas();
            if (listamarcas == null || listamarcas.Count() <= 0)
            {
                return new RespostaApi<IEnumerable<MarcaViewModel>>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Nenhuma marca encontrada." }
                };
            }

            return new RespostaApi<IEnumerable<MarcaViewModel>>
            {
                Erro = false,
                Dados = listamarcas.Select(P => P.ParaViewModel())
            };


        }

        public async Task<RespostaApi<MarcaViewModel>> BuscarMarcaId(int id)
        {
            if (id <= 0)
            {
                return new RespostaApi<MarcaViewModel>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Digite um Id Válido para continuar sua consulta." }
                };
            }
            var retornobanco = await _marcaRepository.BuscarMarcaId(id);

            if (retornobanco == null)
            {
                return new RespostaApi<MarcaViewModel>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Marca não encontrada, verifique o Id!" },
                };
            }
            else
            {
                return new RespostaApi<MarcaViewModel>
                {
                    Erro = false,
                    Dados = retornobanco.ParaViewModel()
                };
            }
        }

        public async Task<RespostaApi<bool>> DeletarMarca(int id)
        {
            if (id <= 0)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Digite um Id Válido para continuar com a exclusão." }
                };
            }
            var buscarmarca = await _marcaRepository.BuscarMarcaId(id);

            if (buscarmarca == null)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Marca não encontrada, verifique o Id!" },
                };
            }

            var marcadeletar = await _marcaService.DeletarMarca(buscarmarca);

            var retornoBanco = _marcaRepository.DeletarMarca(marcadeletar.Dados);

            return new RespostaApi<bool>
            {
                Dados = retornoBanco.Result,

            };
        }

    }
}
