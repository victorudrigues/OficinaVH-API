using AutoMapper;
using OficinaVH.Application.DTOs;
using OficinaVH.Application.IServices;
using OficinaVH.Domain.Entities;
using OficinaVH.Domain.IRepository;
using OficinaVH.Infra.Infrastructure.OficinaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Application.Services
{
    public class ClienteService : IClienteService
    {     //Interface que está sendo implementada na infra
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
        public List<ClienteDTO> GetClientes()
        {
            var clientes = _clienteRepository.GetClientes();
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }
    }
}
