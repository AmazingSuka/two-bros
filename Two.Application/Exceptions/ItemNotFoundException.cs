using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Exceptions
{
    [Serializable]
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(int itemId) : base($"Item with[ID = {itemId}] doesn`t exist in collection")
        {

        }
    }
}
