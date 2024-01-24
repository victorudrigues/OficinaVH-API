using OficinaVH.Domain.Entities;
using OficinaVH.Domain.IRepository;
using OficinaVH.Infra.Infrastructure.OficinaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly Context _context;

        public ClienteRepository(Context context)
        {
            _context = context;
        }

        public List<Clientes> GetClientes()
        {
            var clientes = _context.Clientes.ToList();

            return clientes;
        }
    }
}
