using Boxters.Application.Exceptions;
using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Accounts.Queries.SignInAccount
{
    public class SignInAccountQueryHandler : IRequestHandler<SignInAccountQuery, Unit>
    {
        private readonly IBoxBoxContext _context;

        public SignInAccountQueryHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SignInAccountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Account account = _context.Account.Single(x => x.Login == request.Login);
                UserAccount userAccount = new UserAccount(new Account { Login = request.Login, Password = request.Password });

                await userAccount.SignInAsync(account, request.HttpContext);
                account.LastLogin = DateTime.Now;
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            catch (Exception)
            {
                throw new InvalidPasswordException("The password is wrong");
            }

        }
    }
}
