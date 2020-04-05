using Boxters.Application.Exceptions;
using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Unit>
    {
        private readonly IBoxBoxContext _context;

        public CreateAccountCommandHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            if (_context.Account.SingleOrDefault(x => x.Login == request.Login) != null)
            {
                throw new AccountAlreadyExistException(request.Login);
            }

            if (request.Password != request.RepeatedPassword)
            {
                throw new PasswordsNotEqualException($"Password: {request.Password} \n Repeat Password: {request.RepeatedPassword}");
            }
            UserAccount userAccount = new UserAccount(new Account { Login = request.Login, Email = request.Email, Password = request.Password });

            await userAccount.SignUpAsync(_context, cancellationToken);

            return Unit.Value;
        }
    }
}
