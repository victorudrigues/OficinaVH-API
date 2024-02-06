using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Context _context;
        public ProdutoRepository(Context context) 
        {
            _context = context;
        }

        public void DeleteProduct(Produtos produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public Produtos GetProduct(Guid? id)
        {
            return _context.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public List<Produtos> GetProdutos()
        {
            return _context.Produtos.ToList();
        }

        public string PostProduto(Produtos produto)
        {
            try
            {
                _context.Database.ExecuteSqlRaw("exec sp_CadastraProdutos @Produto, @Valor",
                                    new SqlParameter("@Produto", produto.Produto),
                                    new SqlParameter("@Valor", produto.Valor));
                
                return "Produto cadastrado com sucesso!";
            }
            catch(Exception ex)
            {
                var error = "Erro ao cadastrar produto!";
                throw new Exception(error, ex.InnerException);
            }
            
        }
    }
}
