using OficinaVH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Domain.IRepository
{
    public interface IProdutoRepository
    {
        List<Produtos> GetProdutos();
        string PostProduto(Produtos produto);
        Produtos GetProduct(Guid? id);
        void DeleteProduct(Produtos produto);
    }
}
