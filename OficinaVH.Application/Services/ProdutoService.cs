using AutoMapper;
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

        public List<ProdutoDTO> GetProdutos()
        {
            var produtos = _produtoRepository.GetProdutos();
            return _mapper.Map<List<ProdutoDTO>>(produtos);
        }

        public string PostProduct(Produtos produto)
        {
            return _produtoRepository.PostProduto(produto);
        }
    }
}
