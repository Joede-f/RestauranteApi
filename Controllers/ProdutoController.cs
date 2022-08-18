using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteNascimento.Data.Context;
using RestauranteNascimento.Data.Dtos.ProdutoDtos;
using RestauranteNascimento.Models;
using RestauranteNascimento.Repository.interfaces;
using RestauranteNascimento.Services;

namespace RestauranteNascimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;


        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadProdutoDto>> ListarProdutos()
        {
            return Ok(_produtoService.ListarProdutosService());
        }

        [HttpGet("{id:int}")]
        public ActionResult<ReadProdutoDto> BuscaProduto(int id)
        {
            ReadProdutoDto readDto = _produtoService.BuscaProdutoService(id);
            if (readDto == null) return NotFound("Produto não encontrado");
            return Ok(readDto);

        }

        [HttpPost]
        public ActionResult<ReadProdutoDto> CadatrarProduto([FromBody] CreateProdutoDto creatProdDto)
        {
            ReadProdutoDto readDto = _produtoService.CadatrarProdutoService(creatProdDto);
            return Ok(readDto);
        }

        [HttpPut]
        public ActionResult<ProdutoDto> AtualizaProduto( [FromBody] ProdutoDto prodDto)
        {
            ProdutoDto prod = _produtoService.AtualizaProdutoService(prodDto);
            if (prod == null) return NotFound("Produto não encontrado");
            return Ok(prod);



        }

        [HttpDelete("{id}")]
        public ActionResult DeletarProduto(int id)
        {
            bool res = _produtoService.DeletarProdutoService(id);
            if (res == false) return NotFound("produto não encontrado");
            return Ok("produto Removido");
        }




    }
}
