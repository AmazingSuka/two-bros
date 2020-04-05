using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Exceptions
{
    public class PasswordsNotEqualException : Exception
    {
        public PasswordsNotEqualException(string message) : base(message)
        {
        }
    }
}
