using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
    }
}
