using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIP.MobileAppService.Models;
using HIP.Models;

namespace HIP
{
    public class MockDataStore : IDataStore<Event>
    {
        List<Event> items;

        public MockDataStore()
        {
            items = new List<Event>();
			var mockItems = new List<Event>
            {
                new Event { Id = Guid.NewGuid().ToString(), Name = "First item", Description="This is an item description."},
                new Event { Id = Guid.NewGuid().ToString(), Name = "Second item", Description="This is an item description."},
                new Event { Id = Guid.NewGuid().ToString(), Name = "Third item", Description="This is an item description." },
                new Event { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Description="This is an item description." },
                new Event { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Description="This is an item description." },
                new Event { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Description="This is an item description." }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Event item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Event item)
        {
            var _item = items.Where((Event arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Event arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Event> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Event>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        Task<bool> IDataStore<Event>.AddItemAsync(Event item)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore<Event>.UpdateItemAsync(Event item)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore<Event>.DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<Event> IDataStore<Event>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Event>> IDataStore<Event>.GetItemsAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore<Event>.RegisterUserAsync(UserModel item)
        {
            throw new NotImplementedException();
        }
    }
}
