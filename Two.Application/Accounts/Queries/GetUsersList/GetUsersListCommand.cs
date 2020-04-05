using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Accounts.Queries.GetUsersList
{
    public class GetUsersListCommand : IRequest<IEnumerable<UserLookupModel>>
    {

    }
}
