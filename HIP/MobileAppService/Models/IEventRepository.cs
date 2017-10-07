using System;
using System.Collections.Generic;

namespace HIP.Models
{
    public interface IEventRepository
    {
        void Add(Item item);
        void Update(Item item);
        Item Remove(string email);
        Item Get(string email);
        IEnumerable<Item> GetAll();
    }
}
