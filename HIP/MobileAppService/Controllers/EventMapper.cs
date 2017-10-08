using System;
using System.Collections.Generic;
using HIP.MobileAppService.Models;
using System.Linq;
using HIP.MobileAppService.Models.ClientModels;

namespace HIP.MobileAppService.Controllers
{
    public class EventMapper
    {
        public EventMapper()
        {}

		public List<Event> BuildEventsToDisplay(DateTime startDate, DateTime endDate, IEnumerable<EventModel> storedEvents)
        {
            List<Event> eventsToDisplay = new List<Event>();

			foreach (EventModel storedEvent in storedEvents)
			{
                List<Event> singleEvents = GetSingleOccurrences(storedEvent, startDate, endDate);
                eventsToDisplay.AddRange(singleEvents);

                List<Event> recurringEvents = GetRecurringOccurrences(storedEvent, startDate, endDate);
				eventsToDisplay.AddRange(recurringEvents);
   			}
			return eventsToDisplay.OrderBy(o => o.Start).ToList();
		}

		private List<Event> GetSingleOccurrences(EventModel storedEvent, DateTime startDate, DateTime endDate)
		{
			List<Event> singleOccurrences = new List<Event>();
            foreach (EventOccurrence occurrence in storedEvent.Occurrences)
            {
                if (datesOverlap(occurrence, startDate, endDate) && !IsBlackedOut(occurrence, storedEvent.Blackouts))
                {
					Event newEvent = ConvertEvent(storedEvent, occurrence.Start, occurrence.End);
					singleOccurrences.Add(newEvent);
				}
            }
			return singleOccurrences;
		}

        private List<Event> GetRecurringOccurrences(EventModel storedEvent, DateTime startDate, DateTime endDate)
		{
            List<Event> recurringOccurrences = new List<Event>();
            for (DateTime day = startDate.Date; day.Date <= endDate.Date; day = day.AddDays(1))
            {
				foreach (RecurringEventOccurrence occurrence in storedEvent.RecurringOccurrences)
				{
                    if (occurrence.RecurringDay == day.DayOfWeek )
					{
                        DateTime eventStart = day.Add(occurrence.StartTime);
                        DateTime eventEnd = day.Add(occurrence.EndTime);
                        if (!IsBlackedOut(eventStart, eventEnd, storedEvent.Blackouts))
                        {
							Event newEvent = ConvertEvent(storedEvent, eventStart, eventEnd);
							recurringOccurrences.Add(newEvent);
						}
					}
				}
			}
			return recurringOccurrences;
		}

		private Boolean datesOverlap(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2)
		{
            return startDate1 < endDate2 && startDate2 < endDate1;
		}

		private Boolean datesOverlap(EventOccurrence occ1, DateTime startDate, DateTime endDate)
		{
            return datesOverlap(occ1.Start, occ1.End, startDate, endDate);
		}

		private Boolean IsBlackedOut(EventOccurrence occurrrence, List<EventBlackout> blackoutDates)
		{
			foreach (EventBlackout blackoutDate in blackoutDates)
			{
				if (datesOverlap(occurrrence, blackoutDate.Start, blackoutDate.End))
				{
					return true;
				}
			}
			return false;
		}

        private Boolean IsBlackedOut(DateTime eventStart, DateTime eventEnd, List<EventBlackout> blackoutDates)
		{
			foreach (EventBlackout blackoutDate in blackoutDates)
			{
                if (datesOverlap(eventStart, eventEnd, blackoutDate.Start, blackoutDate.End))
				{
					return true;
				}
			}
			return false;
		}

		private Event ConvertEvent(EventModel storedEvent, DateTime startTime, DateTime endTime)
		{
            return new Event(storedEvent.Id, storedEvent.Name, storedEvent.Description, startTime, endTime, storedEvent.ProgramCategories);
		}

	}

}
