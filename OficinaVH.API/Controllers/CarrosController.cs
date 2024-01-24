using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaVH.Application.DTOs;
using OficinaVH.Application.IServices;
using OficinaVH.Domain.Entities;

namespace OficinaVH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly ICarroService _carroService;

        public CarrosController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet("Listar")]
        public List<CarroDTO>  ListarCarros()
        {
            try
            {
                return _carroService.GetCarros();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost("Criar")]
        public string CriarCarros(Carro carro)
        {
            try
            {
                return _carroService.PostCar(carro);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("Deletar/{Id}")]
        public string DeletarCarro(Guid Id)
        {
            try
            {
                return _carroService.DeleteCar(Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut("Atualizar")]

        public string AtualizarCarro(Carro carro)
        {
            try
            {

                return _carroService.UpdateCar(carro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
