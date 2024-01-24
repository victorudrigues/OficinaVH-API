using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaVH.Application.DTOs;
using OficinaVH.Application.IServices;
using OficinaVH.Application.Services;
using OficinaVH.Domain.Entities;

namespace OficinaVH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
               _clienteService = clienteService;
        }

        [HttpGet("Listar")]
        public List<ClienteDTO> ListarClientes()
        {
            try
            {
                return _clienteService.GetClientes();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost("Criar")]

        public string CriarCliente(Clientes cliente)
        {
            try
            {
                
                return _clienteService.PostClient(cliente);
               
            }
            catch (Exception ex)
            {
                var error = "ERRO AO ADICINAR CLIENTE";
                throw new Exception(error, ex.InnerException);
            }
        }

        [HttpPut("Atualizar")]
        public string AtualizarCliente(Clientes cliente)
        {
            try
            {
                return _clienteService.UpdateClient(cliente);                
            }
            catch (Exception ex ) 
            {
                var error = "ERRO AO ATUALIZAR CLIENTE";
                throw new Exception(error, ex.InnerException);
            }
        }

        [HttpDelete("Deletar/{Id}")]
        public string DelatarCliente(Guid Id)
        {
            try
            {
                return _clienteService.DeleteClient(Id);            }
            catch (Exception ex)
            {
                var error = "Erro ao deletar cliente";
                throw new Exception(error, ex.InnerException);
            }
        }
    }
}
