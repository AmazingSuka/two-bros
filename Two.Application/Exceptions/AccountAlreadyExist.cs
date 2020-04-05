using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Exceptions
{
    public class AccountAlreadyExistException : Exception
    {
        public AccountAlreadyExistException(string login) : base($"Account with login - \"{login}\" already exist.")
        {
        }
    }
}
