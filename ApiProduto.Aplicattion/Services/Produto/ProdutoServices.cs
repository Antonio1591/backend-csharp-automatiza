﻿using ApiProduto.Domain;
using ApiProduto.Domain.InputDomain.Produto;
using ApiProduto.Infrastructure;

namespace ApiProduto.Aplicattion
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoServicesDomain _produtoservices;
        private readonly IProdutoRepository _produtorepository;
        private readonly IMarcaRepository _marcaRepository;
        public ProdutoServices(IProdutoServicesDomain ProdutoService, IProdutoRepository ProdutoRepository, IMarcaRepository marcaRepository)
        {
            _produtoservices = ProdutoService;
            _produtorepository = ProdutoRepository;
            _marcaRepository = marcaRepository;
        }
        public async Task<RespostaApi<bool>> CadastrarProduto(ProdutoInputModel inputModel)
        {
            if (inputModel.Status == StatusProdutoEnum.REMOVIDO)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Não e possivel cadastrar um Produto com o status de removido, favor verificar o status e tentar novamente." }
                };
            }
            var marca = await  _marcaRepository.BuscarMarcaId(inputModel.Marca.Id);
            if(marca == null || marca.Status == StatusMarcaEnum.REMOVIDO)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Marca não encontrada ou marca deletada." }
                };
            }

            var inputdomain = new ProdutoInputDomain { Descricao=inputModel.Descricao,PrecoVenda=inputModel.PrecoVenda,Marca=marca,Estoque=inputModel.Estoque,Status=inputModel.Status};

            var produto = await _produtoservices.CadastrarProduto(inputdomain);

            if (produto.Erro)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = produto.MensagemErro
                };
            }
            var retornoBanco = _produtorepository.CadastrarProduto(produto.Dados);

            return new RespostaApi<bool>
            {
                Dados = retornoBanco.Result,

            };
        }
        public async Task<RespostaApi<bool>> AtualizarProduto(int id,ProdutoInputModel inputModel)
        {
            if (id <= 0)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Digite um Id Válido para continuar sua consulta." }
                };
            }
            var produtoalterar = await _produtorepository.BuscarProdutoId(id);

            if (produtoalterar == null)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Produto não encontrado, verifique o Id!" },
                };
            }
            var marca = await _marcaRepository.BuscarMarcaId(inputModel.Marca.Id);
            if (marca == null || marca.Status == StatusMarcaEnum.REMOVIDO)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Marca não encontrada ou marca deletada." }
                };
            }

            var inputdomain = new ProdutoInputDomain { Descricao = inputModel.Descricao, PrecoVenda = inputModel.PrecoVenda, Marca = marca, Estoque = inputModel.Estoque, Status = inputModel.Status };

            var produtoatualizada = await _produtoservices.AtualizarProduto(produtoalterar, inputdomain);

            if (produtoatualizada.Erro)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = produtoatualizada.MensagemErro
                };
            }
            var retornoBanco = _produtorepository.AtualizarProduto(produtoatualizada.Dados);

            return new RespostaApi<bool>
            {
                Dados = retornoBanco.Result,

            };
        }

        public async Task<RespostaApi<IEnumerable<ProdutoViewModel>>> ListarProdutos()
        {
            var listarprodutos = await _produtorepository.ListarProdutos();
            if (listarprodutos == null || listarprodutos.Count() <= 0 )
            {
                return new RespostaApi<IEnumerable<ProdutoViewModel>>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Nenhum Produto encontrado." }
                };
            }

            return new RespostaApi<IEnumerable<ProdutoViewModel>>
            {
                Erro = false,
                Dados = listarprodutos.Select(P => P.ParaViewModel())
            };


        }

        public async Task<RespostaApi<ProdutoViewModel>> BuscarProdutoId(int id)
        {
            if (id <= 0)
            {
                return new RespostaApi<ProdutoViewModel>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Digite um Id Válido para continuar sua consulta." }
                };
            }
            var retornobanco = await _produtorepository.BuscarProdutoId(id);

            if (retornobanco == null)
            {
                return new RespostaApi<ProdutoViewModel>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Produto não encontrado, verifique o Id!" },
                };
            }
            else
            {
                return new RespostaApi<ProdutoViewModel>
                {
                    Erro = false,
                    Dados = retornobanco.ParaViewModel()
                };
            }
        }

        public async Task<RespostaApi<bool>> DeletarProduto(int id)
        {
            if (id <= 0)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Digite um Id Válido para continuar com a exclusão." }
                };
            }
            var buscarProduto = await _produtorepository.BuscarProdutoId(id);

            if (buscarProduto == null)
            {
                return new RespostaApi<bool>
                {
                    Erro = true,
                    MensagemErro = new List<string> { "Produto não encontrado, verifique o Id!" },
                };
            }

            var Produtodeletar = await _produtoservices.DeletarProduto(buscarProduto);

            var retornoBanco = _produtorepository.DeletarProduto(Produtodeletar.Dados);

            return new RespostaApi<bool>
            {
                Dados = retornoBanco.Result,

            };
        }
    }
}
