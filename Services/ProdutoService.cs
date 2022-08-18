using AutoMapper;
using RestauranteNascimento.Data.Dtos.ProdutoDtos;
using RestauranteNascimento.Models;
using RestauranteNascimento.Repository.interfaces;

namespace RestauranteNascimento.Services
{
    public class ProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _prodRepository;
        private readonly ICategoriaRepository _catRepository;


        public ProdutoService(IMapper mapper, IProdutoRepository prodRepository, ICategoriaRepository catRepository)
        {
            _mapper = mapper;
            _prodRepository = prodRepository;
            _catRepository = catRepository;
        }

        public IEnumerable<ReadProdutoDto> ListarProdutosService()
        {
            IEnumerable<Produto> prod = _prodRepository.GetProdutos();
            IEnumerable<ReadProdutoDto> readDto = _mapper.Map<IEnumerable<ReadProdutoDto>>(prod);
            return readDto;
        }

        public ReadProdutoDto BuscaProdutoService(int id)
        {
            if (id < 1) throw new ArgumentException("Id tem que ser maior do que zero");

            Produto prod = _prodRepository.GetProdutoById(id);
            if (prod == null) return null;

            ReadProdutoDto readDto = _mapper.Map<ReadProdutoDto>(prod);
            return readDto;
        }

        public ReadProdutoDto CadatrarProdutoService(CreateProdutoDto createDto)
        {
            if (createDto.Nome.Length < 3) throw new ArgumentException("o nome deve ter mais do que 3 caracteres");

            if (createDto.Preco <= 0) throw new ArgumentException("o Preço tem que ser maior que zero");

            if (createDto.CategoriaId <= 0) throw new ArgumentException("CategoriaId tem que ser maior que zero");
            Categoria cat = _catRepository.GetCategoriaById(createDto.CategoriaId);
            if (cat == null) throw new ArgumentException("A categoriaId não existe");


            Produto produto = _mapper.Map<Produto>(createDto);
            _prodRepository.PostProduto(produto);
            ReadProdutoDto readDto = _mapper.Map<ReadProdutoDto>(produto);
            return readDto;
        }

        public ProdutoDto AtualizaProdutoService(ProdutoDto prodDto)
        {
            if (prodDto.Id < 1) throw new ArgumentException("Id tem que ser maior do que zero");

            if (prodDto.Nome.Length < 3) throw new ArgumentException("o nome deve ter mais do que 3 caracteres");

            if (prodDto.Preco <= 0) throw new ArgumentException("o Preço tem que ser maior que zero");

            if (prodDto.CategoriaId <= 0) throw new ArgumentException("CategoriaId tem que ser maior que zero");
            Categoria cat = _catRepository.GetCategoriaById(prodDto.CategoriaId);
            if (cat == null) throw new ArgumentException("A categoriaId não existe");

            Produto produto = _mapper.Map<Produto>(prodDto);

            _prodRepository.UpdateProduto(produto);
            prodDto = _mapper.Map<ProdutoDto>(produto);
            return prodDto;
        }

        public bool DeletarProdutoService(int id)
        {
            if (id < 1) throw new ArgumentException("Id tem que ser maior do que zero");

            var produto = _prodRepository.GetProdutoById(id);
            if (produto == null) return false;

            _prodRepository.DeleteProduto(produto);
            return true;
        }
    }
}
