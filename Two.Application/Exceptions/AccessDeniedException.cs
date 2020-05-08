using System;
using System.Collections.Generic;
using System.Text;

namespace Two.Application.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string action) : base($"{action} - User has no permissions to this action.")
        {
        }
    }
}
