using Microsoft.EntityFrameworkCore;
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
    public class CarroRepository : ICarroRepository
    {
        private readonly Context _context;

        public CarroRepository(Context context)
        {
            _context = context;   
        }
        public List<Carro> GetCarros()
        {
           var carros = _context.Carros.ToList();

           return carros;
        }

        public void PostCar(Carro carro)
        {
            
          _context.Carros.Add(carro);
            _context.SaveChanges();
         
        }
        public void DeleteCar(Carro carro)
        {
            _context.Carros.Remove(carro);
            _context.SaveChanges();
        }

        public Carro GetCarro(Guid id)
        {
            var carro = _context.Carros.FirstOrDefault(x => x.Id == id);

            return carro;

        }
    }
}
