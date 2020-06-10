using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Data.Driven.Design.Application.Validations
{
    public abstract class CustomValidator<T> : AbstractValidator<T>, ICustomValidator<T> where T : class
    {
        private ValidationResult _result;
        private bool _isValidationExecuted;
        private bool _isNotified;
        private bool _resultField;

        public bool IsValid => VerifyIsValid();

        public bool Result { get => _resultField; }
        public IList<KeyValuePair<string, string>> Erros { get; set; }


        protected CustomValidator()
        {
            Register();
            _resultField = true;
            Erros = new List<KeyValuePair<string, string>>();
        }

        protected abstract void RegisterValidations();

        public void ValidateAndNotify(T instance)
        {
            if (!_isValidationExecuted)
            {
                _result = Validate(instance);
                _isValidationExecuted = true;
            }

            if (!_result.IsValid && !_isNotified)
            {
                Notify(_result.Errors);
                _isNotified = true;
            }
        }

        public async Task ValidateAndNotifyAsync(T instance, CancellationToken cancellation = new CancellationToken())
        {
            if (!_isValidationExecuted)
            {
                _result = await ValidateAsync(instance, cancellation);
                _isValidationExecuted = true;
            }

            if (!_result.IsValid && !_isNotified)
            {
                Notify(_result.Errors);
                _isNotified = true;
            }
        }

        private void Notify(IList<ValidationFailure> errors)
        {
            if (errors == null)
            {
                return;
            }

            _resultField = false;
            foreach (var error in errors)
            {
                Erros.Add(new KeyValuePair<string, string>(error.PropertyName, error.ErrorMessage));
            }
        }

        private bool VerifyIsValid()
        {
            return _isValidationExecuted && _result.IsValid && Result;
        }

        private void Register()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RegisterValidations();
        }

    }
}
