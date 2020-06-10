using System;
using Data.Driven.Design.Application.Entities;
using Data.Driven.Design.Application.IRepository;
using Data.Driven.Design.Application.Services;

namespace Data.Driven.Design.Application.Services
{
    public class LoadDataBase : ILoadDataBase
    {
        private readonly ICustumerRepository _custumerRepository;

        public LoadDataBase(ICustumerRepository custumerRepository)
        {
            _custumerRepository = custumerRepository;
        }

        public void LoadCustumer()
        {
            CustumerEntity custumer = new CustumerEntity();
            custumer.Id = Guid.NewGuid();
            custumer.Name = "Michael Lens";
            custumer.Email = "m.lens@gmail.com";
            custumer.Senha = "e50b9c3095381fc18cb5f982ad2bf3ec";
            _custumerRepository.InsertAsync(custumer);

            custumer = new CustumerEntity();
            custumer.Id = Guid.NewGuid();
            custumer.Name = "Wagner Bruces";
            custumer.Email = "wag.bru123@gmail.com";
            custumer.Senha = "c6107b3118d53ed9c2107be833cbae7d";
            _custumerRepository.InsertAsync(custumer);
        }
    }
}
