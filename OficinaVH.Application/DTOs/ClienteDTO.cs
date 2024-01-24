using OficinaVH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Application.DTOs
{
    public class ClienteDTO
    {
        public Guid Id { get; set; }
        public string? Cliente { get; set; }
        public Guid? CarroID { get; set; }
        public List<Carro>? Carros { get; set; }
    }
}
