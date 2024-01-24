using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OficinaVH.Application.DTOs;
using OficinaVH.Application.IServices;
using OficinaVH.Domain.Entities;
using OficinaVH.Domain.IRepository;
using OficinaVH.Infra.Infrastructure.OficinaContext;
using OficinaVH.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OficinaVH.Application.Services
{
    public class CarroService : ICarroService
    {
        //Interface que está sendo implementada na infra
        // Todo atributo private tem o (_)
        private readonly ICarroRepository _carroRepository;
        private readonly IMapper _mapper;
        private readonly Context _context;

        public CarroService(ICarroRepository carroRepository, IMapper mapper, Context context)
        {
            _carroRepository = carroRepository;
            _mapper = mapper;
            _context = context;
        }

        public List<CarroDTO> GetCarros()
        {
            try
            {
                var carros = _carroRepository.GetCarros();
                return _mapper.Map<List<CarroDTO>>(carros);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string PostCar(Carro carro)
        {
            try
            {
                 _carroRepository.PostCar(carro);
                return "Carro Adicinado com sucesso";
            }
            catch (Exception ex)
            {
                var error = "Erro ao criar Carro";
                throw new Exception(error,ex.InnerException);
            }
        }

        public string DeleteCar(Guid Id)
        {
            try
            {   //Selecionar carro
                var carro = _carroRepository.GetCarro(Id);
                //Apagar carro
                _carroRepository.DeleteCar(carro);
                return "Carro deletado com sucesso";
            }
            catch (Exception ex)
            {
                var error = "Erro ao deletar Carro";
                throw new Exception(error, ex.InnerException);
            }
        }

        public string UpdateCar(Carro carro)
        {
            try
            {
                // Selecionar carro antigo
                var existingCarro = _carroRepository.GetCarro(carro.Id);


                if (existingCarro != null)
                {
                    // Desanexa a entidade do contexto
                    _context.Entry(existingCarro).State = EntityState.Detached;
                }

                //Passando Carro atualizado
                existingCarro = carro;

                // Informa ao contexto que a entidade foi modificada
                _context.Entry(existingCarro).State = EntityState.Modified;

                // Salva as alterações no banco de dados
                _context.SaveChanges();

                return "Carro Atualizado com sucesso";
            }
            catch (Exception ex)
            {
                var error = "Erro ao atualizar Carro";
                throw new Exception(error, ex.InnerException);
            }
        }
    }
}
