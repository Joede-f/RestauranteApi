using AutoMapper;
using RestauranteNascimento.Data.Dtos.CategoriaDtos;
using RestauranteNascimento.Data.Dtos.ProdutoDtos;
using RestauranteNascimento.Models;

namespace RestauranteNascimento.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CreateCategoriaDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Categoria, ReadCategoriaDto>().ReverseMap();

            CreateMap<Produto, CreateProdutoDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();
            CreateMap<Produto, ReadProdutoDto>().ReverseMap();
        }
    }
}
