using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaVH.Application.DTOs;
using OficinaVH.Application.IServices;
using OficinaVH.Domain.Entities;

namespace OficinaVH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("Listar")]
        public List<ProdutoDTO> GetProdutos()
        {
            try
            {
                return _produtoService.GetProdutos();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult PostProduct(Produtos produto)
        {
            try
            {
                _produtoService.PostProduct(produto);
                return Ok("Produto cadastrado com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult UpdateProduct(Produtos produto)
        {
            try
            {
                _produtoService.UpdateProduct(produto);
                return Ok("Produto atualizado com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Deletar/{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            try
            {   
                _produtoService.DeleteProduct(id);
                return Ok("Produto deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
