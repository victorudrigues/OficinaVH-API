using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaVH.Application.DTOs;
using OficinaVH.Application.IServices;
using OficinaVH.Application.Services;

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

        // Tarefa de amanhã, implementar CRUD CLIENTES E PRODUTOS
    }
}
