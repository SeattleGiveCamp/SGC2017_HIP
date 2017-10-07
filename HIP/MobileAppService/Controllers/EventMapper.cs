using System;
using System.Collections.Generic;
using HIP.MobileAppService.Models;

namespace HIP.MobileAppService.Controllers
{
    public class EventMapper
    {
        public EventMapper()
        {}

		public List<DisplayEvent> BuildEventsToDisplay(DateTime startDate, DateTime endDate, IEnumerable<EventModel> storedEvents)
        {
   //         List<EventModel> eventsToDisplay = new List<EventModel>();

			//foreach (EventModel storedEvent in storedEvents)
			//{
   //             eventsToDisplay.AddRange(GetSingleOccurrences(storedEvent, startDate, endDate));
			//	eventsToDisplay.AddRange(GetRecurringOccurrences(storedEvent, startDate, endDate));
			//	//remove blackouts
			//}
			////sort
            ////translate into new events

            //temp
			return new List<DisplayEvent>();
		}

		private List<DisplayEvent> GetSingleOccurrences(EventModel storedEvent, DateTime startDate, DateTime endDate)
		{
			List<DisplayEvent> singleOccurrences = new List<DisplayEvent>();

   //         foreach (EventOccurrence occurrence in storedEvent.Occurrences)
   //         {
   //             if (datesOverlap(occurrence, startDate, endDate))
   //             {
   //                 singleOccurrences.Add();
   //             }
   //         }

			//	for (var day = startDate.Date; day.Date <= endDate.Date; day = day.AddDays(1))
			//{
			//	foreach (var storedEvent in storedEvents)
			//	{

			//	}
			//	//if single eventOccurrence on date and not blacked out, add
			//	//if recurringEventOccurrence on date and not blacked out, add
			//}
			
			return singleOccurrences;
		}


		private List<DisplayEvent> GetRecurringOccurrences(IEnumerable<EventModel> storedEvents, DateTime startDate, DateTime endDate)
		{
			List<DisplayEvent> singleOccurrences = new List<DisplayEvent>();
			foreach (var storedEvent in storedEvents)
			{

			}

			return singleOccurrences;
		}


		private Boolean datesOverlap(EventOccurrence occ1, DateTime startDate, DateTime endDate )
		{
			return occ1.Start <= endDate || occ1.End >= startDate;
		}


		public class DisplayEvent { }
	}

}
