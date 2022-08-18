using RestauranteNascimento.Models;

namespace RestauranteNascimento.Repository.interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetCategorias();
        Categoria GetCategoriaById(int id);
        void PostCategoria(Categoria categoria);
        void UpdateCategoria(Categoria categoria);
        void DeleteCategoria(Categoria categoria);
    }
}
