using Microsoft.EntityFrameworkCore;
using RestauranteNascimento.Data.Context;
using RestauranteNascimento.Models;
using RestauranteNascimento.Repository.interfaces;

namespace RestauranteNascimento.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        public IEnumerable<Categoria> GetCategoriasComProdutos()
        {
            return _context.Categorias.AsNoTracking().Include(c => c.Produtos).ToList();
        }

        public Categoria GetCategoriaById(int id)
        {
            return _context.Categorias.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public void PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void UpdateCategoria(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public void DeleteCategoria(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }

       
    }
}
