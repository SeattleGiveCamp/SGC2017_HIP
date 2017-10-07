using System;
using System.Collections.Generic;
using System.Text;

namespace HIP.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

		List<EventOccurrence> Occurrences { get; } = new List<EventOccurrence>();
        List<EventBlackout> Blackouts { get; } = new List<EventBlackout>();

        //TODO remove, just to mock
        public Event()
        {
        }

		//For a single-time event
		public Event(string name, string description, TimeSpan eventDuration, TimeSpan hourDuration)
		{
			Name = name;
			Description = description;
			EventOccurrence singleTimeOccurrence = new EventOccurrence(hourDuration, eventDuration);
			Occurrences.Add(singleTimeOccurrence);
		}


		//For a recurring event
		public Event(string name, string description, TimeSpan eventDuration, TimeSpan hourDuration, DayOfWeek occurrenceDay)
		{
			Name = name;
			Description = description;
			Occurrences = new List<EventOccurrence>();
			EventOccurrence singleTimeOccurrence = new RecurringEventOccurrence(hourDuration, eventDuration, occurrenceDay);
			Occurrences.Add(singleTimeOccurrence);
		}


	}
}
