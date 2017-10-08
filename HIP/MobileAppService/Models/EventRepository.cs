using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;


namespace HIP.MobileAppService.Models
{
    public class EventRepository : IEventRepository
    {
        private static ConcurrentDictionary<string, EventModel> eventModels =
            new ConcurrentDictionary<string, EventModel>();

        public EventRepository()
        {
            Add(new EventModel { Id = Guid.NewGuid().ToString(), Name = "Event 1", Description = "This is an item description." });
            Add(new EventModel { Id = Guid.NewGuid().ToString(), Name = "Event 2", Description = "This is an item description." });
            Add(new EventModel { Id = Guid.NewGuid().ToString(), Name = "Event 3", Description = "This is an item description." });
        }

        public EventModel Get(string id)
        {
            return eventModels[id];
        }

        public IEnumerable<EventModel> GetAll()
        {
            return eventModels.Values;
        }

        public void Add(EventModel eventModel)
        {
            eventModel.Id = Guid.NewGuid().ToString();
            eventModels[eventModel.Id] = eventModel;
        }

        public List<EventModel> GetBefore(DateTime date){
            return new List<EventModel>();
        }

        public EventModel Find(string id)
        {
            EventModel eventModel;
            eventModels.TryGetValue(id, out eventModel);

            return eventModel;
        }

        public EventModel Remove(string id)
        {
            EventModel eventModel;
            eventModels.TryRemove(id, out eventModel);

            return eventModel;
        }

        public void Update(EventModel eventModel)
        {
            eventModels[eventModel.Id] = eventModel;
        }
    }
}
