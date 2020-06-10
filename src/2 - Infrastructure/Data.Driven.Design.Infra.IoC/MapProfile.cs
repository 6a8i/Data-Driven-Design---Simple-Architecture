using System;
using AutoMapper;
using Data.Driven.Design.API.Models.Custumer;
using Data.Driven.Design.Application.Entities;

namespace Data.Driven.Design.Infra.IoC
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CustumerEntity, GetAllCustumers.Response>();
            CreateMap<InsertCustumer.Request, CustumerEntity>();

        }
    }
}
