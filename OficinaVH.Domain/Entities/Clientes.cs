using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Domain.Entities
{
    public class Clientes
    {
        public Guid Id { get; set; }
        public string? Cliente { get; set; } 
        public Guid? CarroID { get; set; }
        public List<Carro>? Carros { get; set; }
    }
}
