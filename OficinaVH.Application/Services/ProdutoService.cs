using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OficinaVH.Application.DTOs;
using OficinaVH.Application.IServices;
using OficinaVH.Domain.Entities;
using OficinaVH.Domain.IRepository;
using OficinaVH.Infra.Infrastructure.OficinaContext;
using OficinaVH.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(Context context, IMapper mapper, IProdutoRepository produtoRepository)
        {
            _context = context;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public void DeleteProduct(Guid id)
        {
            try
            {
                var produto = _produtoRepository.GetProduct(id);
                if (produto != null)
                {
                    _produtoRepository.DeleteProduct(produto);
                }
               
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produtos GetProduct(Guid? id)
        {
            try
            {
                return _produtoRepository.GetProduct(id);
            }
            catch (Exception ex)
            {
                var error = "Erro ao localizar Produto selecionado!";
                throw new Exception(error, ex.InnerException);
            }
        }

        public List<ProdutoDTO> GetProdutos()
        {
            var produtos = _produtoRepository.GetProdutos();
            return _mapper.Map<List<ProdutoDTO>>(produtos);
        }

        public string PostProduct(Produtos produto)
        {
            return _produtoRepository.PostProduto(produto);
        }

        public string UpdateProduct(Produtos produto)
        {
            try
            {
                // Selecionar Produto antigo
                var existingProduct = _produtoRepository.GetProduct(produto.Id);


                if (existingProduct != null)
                {
                    // Desanexa a entidade do contexto
                    _context.Entry(existingProduct).State = EntityState.Detached;
                }

                //Passando Produto atualizado
                existingProduct = produto;

                // Informa ao contexto que a entidade foi modificada
                _context.Entry(existingProduct).State = EntityState.Modified;

                // Salva as alterações no banco de dados
                _context.SaveChanges();

                return "Produto Atualizado com sucesso";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
