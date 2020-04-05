using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Exceptions
{

    [Serializable]
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException() : base("Quantity should be greater or equal 0.") { }
    }
}
