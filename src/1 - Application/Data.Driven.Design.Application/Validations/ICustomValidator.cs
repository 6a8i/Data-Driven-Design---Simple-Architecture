using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Driven.Design.Application.Validations
{
    public interface ICustomValidator
    {
        public bool Result { get; }
        public IList<KeyValuePair<string, string>> Erros { get; set; }
    }

    public interface ICustomValidator<in T> : ICustomValidator where T : class
    {
        bool IsValid { get; }

        void ValidateAndNotify(T instance);

        Task ValidateAndNotifyAsync(T instance, CancellationToken cancellation = new CancellationToken());
    }
}
