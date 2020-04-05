using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Accounts.Commands.ChangeRole
{
    public class ChangeRoleCommand : IRequest
    {
        public int AccountId { get; private set; }

        public ChangeRoleCommand(int accountId)
        {
            AccountId = accountId;
        }
    }
}
