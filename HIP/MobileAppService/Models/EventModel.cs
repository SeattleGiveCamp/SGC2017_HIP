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
		public String ProgramCategory { get; set; }

		public List<EventOccurrence> Occurrences { get; set; }
		public List<RecurringEventOccurrence> RecurringOccurrences { get; set; }
		public List<EventBlackout> Blackouts { get; set; }

        public List<EventOccurrence> getOccurrencesSafely() { return Occurrences != null ? Occurrences : new List<EventOccurrence>(); }

        public List<RecurringEventOccurrence> getRecurringOccurrencesSafely(){
            return RecurringOccurrences != null ? RecurringOccurrences : new List<RecurringEventOccurrence>(); 
        }
		public List<EventBlackout> getBlackoutsSafely()
		{
			return Blackouts != null ? Blackouts : new List<EventBlackout>();
		}

        public EventModel()
        {
        }

		//For a single-time event
		public EventModel(string id, string name, string description, DateTime eventStart, DateTime eventEnd, ProgramType type)
		{
			Occurrences = new List<EventOccurrence>();
			RecurringOccurrences = new List<RecurringEventOccurrence>();
			Blackouts = new List<EventBlackout>();

            Id = id;
            Name = name;
			Description = description;
            ProgramCategory = type.Name;
			EventOccurrence singleTimeOccurrence = new EventOccurrence(id, eventStart, eventEnd);
			Occurrences.Add(singleTimeOccurrence);
		}


		//For a recurring event
		public EventModel(string id, string name, string description, TimeSpan eventStart, TimeSpan eventEnd, DateTime recurrenceStart, DateTime recurrenceEnd, DayOfWeek occurrenceDay, ProgramType type)
		{
			Occurrences = new List<EventOccurrence>();
			RecurringOccurrences = new List<RecurringEventOccurrence>();
			Blackouts = new List<EventBlackout>();

			Id = id;
			Name = name;
			Description = description;
            ProgramCategory = type.Name;
            RecurringEventOccurrence returringOccurrence = new RecurringEventOccurrence(eventStart, eventEnd, occurrenceDay, recurrenceStart, recurrenceEnd);
			RecurringOccurrences.Add(returringOccurrence);
		}
	}
}
