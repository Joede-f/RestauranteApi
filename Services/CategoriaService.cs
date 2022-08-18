using AutoMapper;
using RestauranteNascimento.Data.Dtos.CategoriaDtos;
using RestauranteNascimento.Models;
using RestauranteNascimento.Repository.interfaces;

namespace RestauranteNascimento.Services
{
    public class CategoriaService
    {
        private readonly IMapper _mapper;
        private ICategoriaRepository _catRespository;

        public CategoriaService(IMapper mapper, ICategoriaRepository catRespository)
        {
            _mapper = mapper;
            _catRespository = catRespository;
        }

        public IEnumerable<ReadCategoriaDto> ListaCategoriasService()
        {
            IEnumerable<Categoria> categoria = _catRespository.GetCategorias();
            IEnumerable<ReadCategoriaDto> catDto = _mapper.Map<IEnumerable<ReadCategoriaDto>>(categoria);
            return catDto;
        }

        public IEnumerable<ReadCategoriaDto> ListaCategoriasComProdutosService()
        {
            IEnumerable<Categoria> categoria = _catRespository.GetCategoriasComProdutos();
            IEnumerable<ReadCategoriaDto> readDto = _mapper.Map<IEnumerable<ReadCategoriaDto>>(categoria);
            return readDto;
        }

        public ReadCategoriaDto BuscaUmaCategoriaService(int id)
        {
            if (id <= 0) throw new ArgumentException("id precisa ser maior que zero");
            var categoria = _catRespository.GetCategoriaById(id);
            
            if (categoria == null) return null;

            ReadCategoriaDto readCatDto = _mapper.Map<ReadCategoriaDto>(categoria);
            return readCatDto;
        }

        public ReadCategoriaDto CadastraCategoriaService(CreateCategoriaDto createDto)
        {
            if (createDto.NomeCat.Length < 3) throw new ArgumentException(" o nomeCat deve ter mais do que 3 caracteres");

            Categoria cat = _mapper.Map<Categoria>(createDto);
            _catRespository.PostCategoria(cat);
            ReadCategoriaDto readDto = _mapper.Map<ReadCategoriaDto>(cat);
            return readDto;
        }

        public ReadCategoriaDto AtualizarCategoriaService(ReadCategoriaDto readDto)
        {
            if (readDto.Id < 1) throw new ArgumentException("id precisa ser maior que zero");
            if (readDto.NomeCat.Length < 3) throw new ArgumentException("o nome deve ter mais do que 3 caracteres");

            Categoria cat = _catRespository.GetCategoriaById(readDto.Id);
            if (cat == null) return null;
            cat = _mapper.Map<Categoria>(readDto);
            _catRespository.UpdateCategoria(cat);

            readDto = _mapper.Map<ReadCategoriaDto>(cat);
            return readDto;
        }

        public bool DeleteCategoriaService(int id)
        {
            if (id < 1) throw new ArgumentException("id precisa ser maior que zero");

            Categoria categoria = _catRespository.GetCategoriaById(id);
            if (categoria == null) return false;

            _catRespository.DeleteCategoria(categoria);
            return true; ;
        }
    }
}
