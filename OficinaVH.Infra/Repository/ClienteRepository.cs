using OficinaVH.Domain.Entities;
using OficinaVH.Domain.IRepository;
using OficinaVH.Infra.Infrastructure.OficinaContext;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void DeleteCliente(Clientes cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public Clientes GetCliente(Guid id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            return cliente;
        }

        public List<Clientes> GetClientes()
        {
            var clientes = _context.Clientes.ToList();

            return clientes;
        }

        public void PostClient(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }
    }
}
