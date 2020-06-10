using System;
namespace Data.Driven.Design.API.Models.Custumer
{
    public class InsertCustumer
    {
        public class Request
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Response : BaseResponse
        {

        }
    }
}
