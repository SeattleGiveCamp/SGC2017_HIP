using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                new Event { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description.", Date=DateTime.Now.ToShortDateString() },
                new Event { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." , Date=DateTime.Now.ToShortDateString()},
                new Event { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." , Date=DateTime.Now.ToShortDateString()},
                new Event { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." , Date=DateTime.Now.ToShortDateString()},
                new Event { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." , Date=DateTime.Now.ToShortDateString()},
                new Event { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." , Date=DateTime.Now.ToShortDateString()},
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
    }
}
