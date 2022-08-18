using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteNascimento.Data.Context;
using RestauranteNascimento.Data.Dtos.CategoriaDtos;
using RestauranteNascimento.Models;
using RestauranteNascimento.Repository.interfaces;

namespace RestauranteNascimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICategoriaRepository _catRespository;

        public CategoriaController(AppDbContext context, IMapper mapper, ICategoriaRepository catRespository)
        {
            _mapper = mapper;
            _catRespository = catRespository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadCategoriaDto>> ListaCategorias()
        {
            
            IEnumerable<Categoria> categoria = _catRespository.GetCategorias();
            IEnumerable<ReadCategoriaDto> catDto = _mapper.Map<IEnumerable<ReadCategoriaDto>>(categoria);
            return Ok(catDto);
        }


        [HttpGet("{id:int}")]
        public ActionResult<ReadCategoriaDto> BuscaUmaCategoria(int id)
        {
            if(id <= 0) throw new ArgumentException("id precisa ser maior que zero");


            var categoria = _catRespository.GetCategoriaById(id);
            if (categoria == null) return NotFound("categoria não encontrada");

            ReadCategoriaDto ReadCatDto = _mapper.Map<ReadCategoriaDto>(categoria);

            return Ok(ReadCatDto);
        }

        [HttpPost]
        public ActionResult<ReadCategoriaDto> CadastraCategoria([FromBody] CreateCategoriaDto createDto)
        {
            if(createDto.NomeCat.Length < 3) throw new ArgumentException(" o nomeCat deve ter mais do que 3 caracteres");
            
            Categoria cat = _mapper.Map<Categoria>(createDto);
            _catRespository.PostCategoria(cat);
            ReadCategoriaDto readDto = _mapper.Map<ReadCategoriaDto>(cat);
            return Ok(readDto);
        }

        [HttpPut]
        public ActionResult<ReadCategoriaDto> AtualizarCategoria([FromBody] ReadCategoriaDto catDto)
        {
            if(catDto.Id < 1) throw new ArgumentException("id precisa ser maior que zero");
            if (catDto.NomeCat.Length < 3) throw new ArgumentException("o nome deve ter mais do que 3 caracteres");


            Categoria cat = _mapper.Map<Categoria>(catDto);
            _catRespository.UpdateCategoria(cat);

            ReadCategoriaDto readDto = _mapper.Map<ReadCategoriaDto>(cat);
            return Ok(readDto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> DeletarCategoria(int id)
        {
            if (id < 1)  throw new ArgumentException("id precisa ser maior que zero");

            var categoria = _catRespository.GetCategoriaById(id);
            if (categoria == null) return NotFound("categoria não encontrada");

            _catRespository.DeleteCategoria(categoria);
            return Ok($"Id {id} Deletado");

        }
    }
}
