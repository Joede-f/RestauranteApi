using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteNascimento.Data.Context;
using RestauranteNascimento.Data.Dtos.ProdutoDtos;
using RestauranteNascimento.Models;

namespace RestauranteNascimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public ProdutoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadProdutoDto>> ListarProdutos()
        {
            IEnumerable<Produto> prod = _context.Produtos.ToList();
            IEnumerable<ReadProdutoDto> readDto = _mapper.Map<IEnumerable<ReadProdutoDto>>(prod);
            return Ok(readDto);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ReadProdutoDto> BuscaProduto(int id)
        {
            if(id < 1) throw new ArgumentException("Id tem que ser maior do que zero");


            Produto prod = _context.Produtos.Find(id);
            if (prod == null) return NotFound("Produto não encontrado");

            ReadProdutoDto readDto = _mapper.Map<ReadProdutoDto>(prod);
            return Ok(readDto);

        }

        [HttpPost]
        public ActionResult<ReadProdutoDto> CadatrarProduto([FromBody] CreateProdutoDto creatProdDto)
        {
            if (creatProdDto.Nome.Length < 3) throw new ArgumentException("o nome deve ter mais do que 3 caracteres");
            
            if(creatProdDto.Preco <= 0) throw new ArgumentException("o Preço tem que ser maior que zero");

            if(creatProdDto.CategoriaId <= 0) throw new ArgumentException("CategoriaId tem que ser maior que zero");

            Categoria categoria = _context.Categorias.Find(creatProdDto.CategoriaId);
            if (categoria == null) throw new ArgumentException("não é possivel cadastrar o produto, CategoriaId não existe");

            Produto produto = _mapper.Map<Produto>(creatProdDto);
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            ReadProdutoDto readDto = _mapper.Map<ReadProdutoDto>(produto);
            return Ok(readDto);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ProdutoDto> AtualizaProduto(int id, [FromBody] ProdutoDto prodDto)
        {
            if (id < 1) throw new ArgumentException("Id tem que ser maior do que zero");

            if (prodDto.Nome.Length < 3) throw new ArgumentException("o nome deve ter mais do que 3 caracteres");

            if (prodDto.Preco <= 0) throw new ArgumentException("o Preço tem que ser maior que zero");

            if (prodDto.CategoriaId <= 0) throw new ArgumentException("CategoriaId tem que ser maior que zero");

            Categoria categoria = _context.Categorias.Find(prodDto.CategoriaId);
            if (categoria == null) throw new ArgumentException("não é possivel alterar o produto, CategoriaId não existe");

            Produto produto = _context.Produtos.Find(id);
            produto = _mapper.Map<Produto>(prodDto);
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            prodDto = _mapper.Map<ProdutoDto>(produto);
            return Ok(prodDto);

        }

        [HttpDelete("{id}")]
        public ActionResult DeletarProduto(int id)
        {
            if (id < 1) throw new ArgumentException("Id tem que ser maior do que zero");

            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound("Produto não encontrado");

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return NoContent();
        }




    }
}
