using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Driven.Design.API.Models.Custumer;

namespace Data.Driven.Design.Application.Services.Custumer
{
    public interface ICustumerService
    {
        Task<IEnumerable<GetAllCustumers.Response>>GetAllCustumersAsync();

        Task<InsertCustumer.Response> InsertCustumerAsync(InsertCustumer.Request request);
    }
}
