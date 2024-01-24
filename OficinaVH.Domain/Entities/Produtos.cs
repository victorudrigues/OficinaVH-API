using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Domain.Entities
{
    public class Produtos
    {
        public Guid Id { get; set; }
        public string Produto { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public Carro? Carro { get; set; }
    }
}
