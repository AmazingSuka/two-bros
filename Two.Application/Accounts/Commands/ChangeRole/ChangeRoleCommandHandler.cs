using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Two.Application.Exceptions;

namespace Boxters.Application.Accounts.Commands.ChangeRole
{
    public class ChangeRoleCommandHandler : IRequestHandler<ChangeRoleCommand>
    {
        private readonly IBoxBoxContext _context;

        public ChangeRoleCommandHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
        {
            Account account = _context.Account.Find(request.AccountId);

            if (account.IsOwner)
            {
                throw new AccessDeniedException("ChangeRole - Change owner`s role");
            }

            account.IsSuperUser = !account.IsSuperUser;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
