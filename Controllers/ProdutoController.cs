using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteNascimento.Data.Context;
using RestauranteNascimento.Data.Dtos.ProdutoDtos;
using RestauranteNascimento.Models;
using RestauranteNascimento.Repository.interfaces;

namespace RestauranteNascimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _prodRepository;


        public ProdutoController(IMapper mapper, IProdutoRepository prodRepository)
        {
            _mapper = mapper;
            _prodRepository = prodRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadProdutoDto>> ListarProdutos()
        {
            IEnumerable<Produto> prod = _prodRepository.GetProdutos();
            IEnumerable<ReadProdutoDto> readDto = _mapper.Map<IEnumerable<ReadProdutoDto>>(prod);
            return Ok(readDto);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ReadProdutoDto> BuscaProduto(int id)
        {
            if(id < 1) throw new ArgumentException("Id tem que ser maior do que zero");


            Produto prod = _prodRepository.GetProdutoById(id);
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


            Produto produto = _mapper.Map<Produto>(creatProdDto);
            _prodRepository.PostProduto(produto);
            ReadProdutoDto readDto = _mapper.Map<ReadProdutoDto>(produto);
            return Ok(readDto);
        }

        [HttpPut]
        public ActionResult<ProdutoDto> AtualizaProduto( [FromBody] ProdutoDto prodDto)
        {
            if (prodDto.Id < 1) throw new ArgumentException("Id tem que ser maior do que zero");

            if (prodDto.Nome.Length < 3) throw new ArgumentException("o nome deve ter mais do que 3 caracteres");

            if (prodDto.Preco <= 0) throw new ArgumentException("o Preço tem que ser maior que zero");

            if (prodDto.CategoriaId <= 0) throw new ArgumentException("CategoriaId tem que ser maior que zero");

            Produto produto = _mapper.Map<Produto>(prodDto);

            _prodRepository.UpdateProduto(produto);
            prodDto = _mapper.Map<ProdutoDto>(produto);
            return Ok(prodDto);



        }

        [HttpDelete("{id}")]
        public ActionResult DeletarProduto(int id)
        {
            if (id < 1) throw new ArgumentException("Id tem que ser maior do que zero");

            var produto = _prodRepository.GetProdutoById(id);
            if (produto == null) return NotFound("Produto não encontrado");

            _prodRepository.DeleteProduto(produto);
            return NoContent();
        }




    }
}
