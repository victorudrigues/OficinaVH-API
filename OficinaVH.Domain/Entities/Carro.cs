using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Domain.Entities
{
    public class Carro
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public Guid? ClienteID { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Ano { get; set; } = string.Empty;
        public Guid? ProdutoID { get; set; }
        public List<Produtos>? Produtos { get; set; }
        public Clientes? Clientes { get; set; }
 
    }
}

