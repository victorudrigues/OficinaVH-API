using OficinaVH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Domain.IRepository
{
    public interface ICarroRepository
    {
        List<Carro> GetCarros();
        void PostCar(Carro carro);
        void DeleteCar(Carro carro);
        Carro GetCarro(Guid id);
        //Configurando git user

        
    }
}
