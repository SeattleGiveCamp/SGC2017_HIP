using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;


namespace HIP.MobileAppService.Models
{
    public class EventRepository : IEventRepository
    {

        public EventRepository()
        {
        }

        public EventModel Get(string id)
        {
            using (var db = new HIPContext())
            {
                var events = db.Events
                    .Where(b => b.Id == id)
                    .ToList();

                return events.ElementAt(0);
            }
        }

        public IEnumerable<EventModel> GetAll()
        {
            using (var db = new HIPContext())
            {
                var events = db.Events
                    .ToList();

                return events;
            }
        }

        public void Add(EventModel eventModel)
        {
            try
            {
                using (var db = new HIPContext())
                {
                    db.Events.Add(eventModel);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool Remove(string id)
        {
            //using (var db = new HIPContext())
            //{
            //    var events = db.Events
            //        .Where(b => b.Id == id)
            //        .ToList();

            //    return db.Remove(events.ElementAt(0));
            //}
            return true;
        }

        public void Update(EventModel eventModel)
        {
            using (var db = new HIPContext())
            {
                var events = db.Events.Attach(eventModel);
                db.SaveChanges();
            }
        }
    }
}
