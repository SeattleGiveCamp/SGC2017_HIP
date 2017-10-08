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
		public List<ProgramType> ProgramCategories { get; set; }

		public List<EventOccurrence> Occurrences { get; }
        public List<RecurringEventOccurrence> RecurringOccurrences { get; }
        public List<EventBlackout> Blackouts { get; }

        //TODO remove, just to mock
        public EventModel()
        {
        }

		//For a single-time event
		public EventModel(string id, string name, string description, DateTime eventStart, DateTime eventEnd, EventType type)
		{
			Occurrences = new List<EventOccurrence>();
			RecurringOccurrences = new List<RecurringEventOccurrence>();
			Blackouts = new List<EventBlackout>();

            Id = id;
            Name = name;
			Description = description;
            Type = type;
			EventOccurrence singleTimeOccurrence = new EventOccurrence(id, eventStart, eventEnd);
			Occurrences.Add(singleTimeOccurrence);
		}


		//For a recurring event
		public EventModel(string id, string name, string description, TimeSpan eventStart, TimeSpan eventEnd, DateTime recurrenceStart, DateTime recurrenceEnd, DayOfWeek occurrenceDay, EventType type)
		{
			Occurrences = new List<EventOccurrence>();
			RecurringOccurrences = new List<RecurringEventOccurrence>();
			Blackouts = new List<EventBlackout>();

			Id = id;
			Name = name;
			Description = description;
			Type = type;
            RecurringEventOccurrence returringOccurrence = new RecurringEventOccurrence(eventStart, eventEnd, occurrenceDay, recurrenceStart, recurrenceEnd);
			RecurringOccurrences.Add(returringOccurrence);
		}
	}
}
