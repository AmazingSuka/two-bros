using Boxters.Application.Accounts.Commands.CreateAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxters.WebUI.Models
{
    public class SignUpViewModel
    {
        public CreateAccountCommand Command { get; set; }
    }
}
