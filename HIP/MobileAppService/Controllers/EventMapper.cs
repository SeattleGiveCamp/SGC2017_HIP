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
            List<DisplayEvent> eventsToDisplay = new List<DisplayEvent>();

			foreach (EventModel storedEvent in storedEvents)
			{
                List<DisplayEvent> singleEvents = GetSingleOccurrences(storedEvent, startDate, endDate);
                eventsToDisplay.AddRange(singleEvents);

                List<DisplayEvent> recurringEvents = GetRecurringOccurrences(storedEvent, startDate, endDate);
				eventsToDisplay.AddRange(recurringEvents);
   			}
            //TODO: sort

			return eventsToDisplay;
		}

		private List<DisplayEvent> GetSingleOccurrences(EventModel storedEvent, DateTime startDate, DateTime endDate)
		{
			List<DisplayEvent> singleOccurrences = new List<DisplayEvent>();
            foreach (EventOccurrence occurrence in storedEvent.Occurrences)
            {
                if (datesOverlap(occurrence, startDate, endDate) && !IsBlackedOut(occurrence, storedEvent.Blackouts))
                {
                    singleOccurrences.Add(new DisplayEvent());  //TODO: build event
                }
            }
			return singleOccurrences;
		}

        private List<DisplayEvent> GetRecurringOccurrences(EventModel storedEvent, DateTime startDate, DateTime endDate)
		{
            List<DisplayEvent> recurringOccurrences = new List<DisplayEvent>();
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
							recurringOccurrences.Add(new DisplayEvent());  //TODO: build event
						}
					}
				}
			}
			return recurringOccurrences;
		}

		private Boolean datesOverlap(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2)
		{
			return startDate1 <= endDate2 || endDate1 >= startDate2;
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

		public class DisplayEvent { }
	}

}
