using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Driven.Design.API.Models;
using Data.Driven.Design.API.Models.Custumer;
using Data.Driven.Design.Application.Entities;
using Data.Driven.Design.Application.IRepository;
using Data.Driven.Design.Application.Validations;

namespace Data.Driven.Design.Application.Services.Custumer
{
    public class CustumerService : ICustumerService
    {
        private readonly ICustumerRepository _repo;
        private readonly IMapper _mapper;
        private readonly ICustomValidator<InsertCustumer.Request> _validator;

        public CustumerService(ICustumerRepository repo, IMapper mapper, ICustomValidator<InsertCustumer.Request> validator)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllCustumers.Response>> GetAllCustumersAsync()
        {
            var result = _mapper.Map<IEnumerable<GetAllCustumers.Response>>(await _repo.GetAllAsync());

            return result;
        }

        public async Task<InsertCustumer.Response> InsertCustumerAsync(InsertCustumer.Request request)
        {
            //Validate
            await _validator.ValidateAndNotifyAsync(request);

            if (!_validator.IsValid)
                return new InsertCustumer.Response().SetErrors(_validator.Erros);

            // Act
            var entity = _mapper.Map<CustumerEntity>(request);
            await _repo.InsertAsync(entity);

            // Return
            return new InsertCustumer.Response();
        }
    }
}
