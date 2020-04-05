using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Accounts.Queries.SignOutAccount
{
    public class SignOutAccountQueryHandler : IRequestHandler<SignOutAccountQuery, Unit>
    {
        public async Task<Unit> Handle(SignOutAccountQuery request, CancellationToken cancellationToken)
        {
            UserAccount userAccount = new UserAccount();

            await userAccount.SignOutAsync(request.HttpContext);

            return Unit.Value;
        }
    }
}
