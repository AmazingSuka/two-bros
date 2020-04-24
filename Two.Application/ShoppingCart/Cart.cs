using Boxters.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Boxters.Application.ShoppingCart
{
    [Serializable]
    public class Cart
    {
        private IDictionary<int, short> selectedItems;

        public Cart()
        {
            selectedItems = new Dictionary<int, short>();
        }

        public void Add(int foodId)
        {
            if (selectedItems.ContainsKey(foodId))
            {
                selectedItems[foodId] += 1;
            }
            else
            {
                selectedItems.Add(foodId, 1);
            }
        }
        
        public void Set(int foodId, short quantity)
        {
            if (quantity < 0)
            {
                throw new InvalidQuantityException();
            }

            if (quantity.Equals(0))
            {
                if (selectedItems.ContainsKey(foodId))
                {
                    selectedItems.Remove(foodId);
                }
            }
            else
            {
                if (selectedItems.ContainsKey(foodId))
                {
                    selectedItems[foodId] += quantity;
                }
                else
                {
                    selectedItems.Add(foodId, quantity);
                }
            }        
        }

        public void Remove(int foodId)
        {
            if (!selectedItems.ContainsKey(foodId))
            {
                throw new ItemNotFoundException(foodId);
            }

            if (selectedItems[foodId] > 1)
            {
                selectedItems[foodId] -= 1;
            }
            else
            {
                selectedItems.Remove(foodId);
            }
        }

        public void Clear()
        {
            selectedItems.Clear();
        }

        public int Count()
        {
            int count = 0;

            foreach (var item in selectedItems)
            {
                count += item.Value;
            }
            return count;
        }

        public short GetQuantity(int foodId)
        {
            if (!selectedItems.ContainsKey(foodId))
            {
                return 0;
            }

            return selectedItems[foodId];
        }

        public IEnumerable<int> GetKeys()
        {
            return selectedItems.Keys;
        }

        public void Save(ISession session)
        {
            session.Set("Cart", this.ToByteArray());
        }

        public byte[] ToByteArray()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, this);
                return memoryStream.ToArray();
            }
        }

        public static Cart FromByteArray(byte[] obj)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (MemoryStream memoryStream = new MemoryStream(obj))
            {
                return binaryFormatter.Deserialize(memoryStream) as Cart;
            }
        }
    }
}
