using OficinaVH.Application.DTOs;
using OficinaVH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Application.IServices
{
    public interface IProdutoService
    {
        List<ProdutoDTO> GetProdutos();
        string PostProduct(Produtos produto);
    }
}
