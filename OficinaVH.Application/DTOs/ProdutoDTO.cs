using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Application.DTOs
{
    public class ProdutoDTO
    {
        public Guid? id { get; set; }
        public string Produto { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}
