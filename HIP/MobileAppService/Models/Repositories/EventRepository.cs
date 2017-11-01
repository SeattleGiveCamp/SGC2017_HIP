using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

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
				   .Include(e => e.RecurringOccurrences)
    			   .Include(e => e.Occurrences)
    			   .Include(e => e.Blackouts)
                    .ToList();
                return events.Count() > 0 ? events.ElementAt(0) : null;
            }
        }

        public IEnumerable<EventModel> GetAll()
        {
            using (var db = new HIPContext())
            {
                try
                {
					var events = db.Events
								   .Include(e => e.RecurringOccurrences)
                                   .Include(e => e.Occurrences)
                                   .Include(e => e.Blackouts)
						           .ToList();

                    return events;
                }
				catch (Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
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
             throw new Exception("removing is not currently supported");
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
