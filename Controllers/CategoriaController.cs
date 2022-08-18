using Microsoft.AspNetCore.Mvc;
using RestauranteNascimento.Data.Dtos.CategoriaDtos;
using RestauranteNascimento.Models;
using RestauranteNascimento.Services;

namespace RestauranteNascimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadCategoriaDto>> ListaCategorias()
        {
            return Ok(_categoriaService.ListaCategoriasService());
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<ReadCategoriaDto>> ListaCategoriasComProdutos()
        {
            return Ok(_categoriaService.ListaCategoriasComProdutosService());     
        }


        [HttpGet("{id:int}")]
        public ActionResult<ReadCategoriaDto> BuscaUmaCategoria(int id)
        {
            ReadCategoriaDto readDto = _categoriaService.BuscaUmaCategoriaService(id);
            if (readDto == null) return NotFound("categoria Não encontrada");
            return readDto;
        }

        [HttpPost]
        public ActionResult<ReadCategoriaDto> CadastraCategoria([FromBody] CreateCategoriaDto createDto)
        {
           ReadCategoriaDto readDto = _categoriaService.CadastraCategoriaService(createDto);
            return Ok(readDto);
        }

        [HttpPut]
        public ActionResult<ReadCategoriaDto> AtualizarCategoria([FromBody] ReadCategoriaDto catDto)
        {

            ReadCategoriaDto readDto = _categoriaService.AtualizarCategoriaService(catDto);
            if (readDto == null) return NotFound("Categoria não encontrada");
            return Ok(readDto);

        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> DeletarCategoria(int id)
        {
            bool res = _categoriaService.DeleteCategoriaService(id);
            if (res == false) return NotFound("categoria não encontrada");
            return Ok("Categoria Removida");
        }
    }
}
