using System.Collections.Generic;
using System.Linq;

namespace Data.Driven.Design.API.Models
{
    public class BaseResponse
    {
        public class Error
        {
            public string Campo { get; set; }
            public string Mensagem { get; set; }
        }

        public IList<Error> Errors { get; set; }

        public bool HasSucced()
        {
            return Errors == null || Errors.Count == 0;
        }
    }

    public static class BaseResponseExtensions
    {
        public static T SetErrors<T>(this T response, IList<KeyValuePair<string, string>> errors) where T : BaseResponse
        {
            response.Errors = errors.Select(kv => new BaseResponse.Error { Campo = kv.Key, Mensagem = kv.Value }).ToList();
            return response;
        }
    }
}
