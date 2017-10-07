using System;
using System.Collections.Generic;
using System.Text;

namespace HIP.MobileAppService.Models
{
    public class EventModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EventType Type{ get; set; }

		public List<EventOccurrence> Occurrences { get; } = new List<EventOccurrence>();
		public List<RecurringEventOccurrence> RecurringOccurrences { get; } = new List<RecurringEventOccurrence>();
		public List<EventBlackout> Blackouts { get; } = new List<EventBlackout>();

        //TODO remove, just to mock
        public EventModel()
        {
        }

		//For a single-time event
		public EventModel(string id, string name, string description, DateTime eventStart, DateTime eventEnd, EventType type)
		{
            Id = id;
            Name = name;
			Description = description;
            Type = type;
			EventOccurrence singleTimeOccurrence = new EventOccurrence(eventStart, eventEnd);
			Occurrences.Add(singleTimeOccurrence);
		}


		//For a recurring event
		public EventModel(string id, string name, string description, DateTime eventStart, DateTime eventEnd, DateTime recurrenceStart, DateTime recurrenceEnd, DayOfWeek occurrenceDay, EventType type)
		{
			Id = id;
			Name = name;
			Description = description;
			Type = type;
            RecurringEventOccurrence returringOccurrence = new RecurringEventOccurrence(eventStart, eventEnd, occurrenceDay, recurrenceStart, recurrenceEnd);
			RecurringOccurrences.Add(returringOccurrence);
		}
	}
}
