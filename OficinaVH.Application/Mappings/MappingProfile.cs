using AutoMapper;
using OficinaVH.Application.DTOs;
using OficinaVH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Application.Mappings
{
    //Auto mapper
    //Mappeando entidades
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Carro, CarroDTO>().ReverseMap();
            CreateMap<Clientes, ClienteDTO>().ReverseMap();
        }
    }
}
