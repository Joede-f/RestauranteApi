using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteNascimento.Data.Context;
using RestauranteNascimento.Models;
using RestauranteNascimento.Repository.interfaces;

namespace RestauranteNascimento.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> GetProdutos()
        {
            return _context.Produtos.AsNoTracking().ToList();
        }

        public Produto GetProdutoById(int id)
        {
            return _context.Produtos.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public void PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void UpdateProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges(); ;
        }

        public void DeleteProduto(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }


    }
}
