using RestauranteNascimento.Models;

namespace RestauranteNascimento.Repository.interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetProdutos();
        Produto GetProdutoById(int id);
        void PostProduto(Produto categoria);
        void UpdateProduto(Produto categoria);
        void DeleteProduto(Produto categoria);
    }
}
