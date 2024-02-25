using ApiProduto.Domain;
using ApiProduto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiProduto.Infrastructure
{
    public class MarcaRepository:IMarcaRepository
    {
        private readonly DataContext _context;

        public MarcaRepository(DataContext dataCotnext)
        {
            _context = dataCotnext;
        }

        public async Task<bool> CadastrarMarca(Marca marca)
        {
            await   _context.Marcas.AddAsync(marca);

           await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AtualizarMarca(Marca marca)
        {
            _context.Update(marca);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<Marca>> ListarMarcas()
        {
            return await _context.Marcas.ToListAsync();

        }

        public async Task<Marca> BuscarMarcaId(int id)
        {
            var marca = await _context.Marcas.FirstOrDefaultAsync(I => I.Id == id);

            return marca;
        }

        public async Task<bool> DeletarMarca(Marca marca)
        {
            _context.Update(marca);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}

