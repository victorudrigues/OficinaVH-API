using OficinaVH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Domain.IRepository
{
    public interface IClienteRepository
    {
        List<Clientes> GetClientes();
        void PostClient(Clientes cliente);
        Clientes GetCliente(Guid id);
        void DeleteCliente(Clientes Cliente);
    }
}
