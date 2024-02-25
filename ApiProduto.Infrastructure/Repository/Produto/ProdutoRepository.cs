using ApiProduto.Domain;
using ApiProduto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiProduto.Infrastructure
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext dataCotnext)
        {
            _context = dataCotnext;
        }

        public async Task<bool> CadastrarProduto(Produto Produto)
        {
            await _context.Produto.AddAsync(Produto);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AtualizarProduto(Produto Produto)
        {
            _context.Update(Produto);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            return await _context.Produto.Include(M=>M.Marca)
                                          .ToListAsync();

        }

        public async Task<Produto> BuscarProdutoId(int id)
        {
            return await _context.Produto.Include(M => M.Marca)
                                        .FirstOrDefaultAsync(I => I.Id == id);

        }

        public async Task<bool> DeletarProduto(Produto Produto)
        {
            _context.Update(Produto);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
