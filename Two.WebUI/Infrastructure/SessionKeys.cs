using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxters.WebUI.Infrastructure
{
    public static class SessionKeys
    {
        public const string Cart = "Cart";
        public const string AuthError = "AuthError";
        public const string AccountAlreadyExistError = "AlreadyExistError";
        public const string PasswordsNotEqualError = "PasswordsNotEqualError";
        public const string SignUpSuccess = "SignUpSuccess";
    }
}
