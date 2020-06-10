using System;
namespace Data.Driven.Design.API.Models.Custumer
{
    public class GetAllCustumers
    {
        public class Response : BaseResponse
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}
