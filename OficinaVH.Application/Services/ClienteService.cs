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

namespace OficinaVH.Application.Services
{
    public class ClienteService : IClienteService
    {     
        //Interface que está sendo implementada na infra
        // Todo atributo private tem o (_)
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly Context _context;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper, Context context)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _context = context;
        }

        public string DeleteClient(Guid Id)
        {
            try
            {
                var cliente = _clienteRepository.GetCliente(Id);

                //Selecionar cliente pelo id passado
                if (cliente != null)
                {
                    _clienteRepository.DeleteCliente(cliente);
                }

                return "Cliente deletado com sucesso";        
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ClienteDTO> GetClientes()
        {
            var clientes = _clienteRepository.GetClientes();
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }

        public string PostClient(Clientes cliente)
        {
            try
            {
                
                _clienteRepository.PostClient(cliente);
                return "Cliente Adicionado com sucesso!";   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string UpdateClient(Clientes cliente)
        {
            try
            {
                // Selecionar carro antigo
                var existingClient = _clienteRepository.GetCliente(cliente.Id);


                if (existingClient != null)
                {
                    // Desanexa a entidade do contexto
                    _context.Entry(existingClient).State = EntityState.Detached;
                }

                //Passando Carro atualizado
                existingClient = cliente;

                // Informa ao contexto que a entidade foi modificada
                _context.Entry(existingClient).State = EntityState.Modified;

                // Salva as alterações no banco de dados
                _context.SaveChanges();

                return "Cliente Atualizado com sucesso";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
