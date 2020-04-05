using System;
using System.Collections.Generic;
using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using System.Linq;

namespace Boxters.Application.Infrastructure
{
    public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
            
            var failures = _validators
                .Select(x => x.Validate(context))
                .SelectMany(res => res.Errors)
                .Where(x => x != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}
