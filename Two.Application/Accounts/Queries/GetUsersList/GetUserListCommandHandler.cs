using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Accounts.Queries.GetUsersList
{
    public class GetUserListCommandHandler : IRequestHandler<GetUsersListCommand, IEnumerable<UserLookupModel>>
    {
        private readonly IBoxBoxContext _context;

        public GetUserListCommandHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<UserLookupModel>> Handle(GetUsersListCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _context.Account.Select(
                    acc => new UserLookupModel(acc.Id, acc.Login, acc.IsSuperUser)
                    ).AsEnumerable()
                );
        }
    }
}
