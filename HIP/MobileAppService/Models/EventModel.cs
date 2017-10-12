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

        private List<EventOccurrence> Occurrences;
        public List<EventOccurrence> getOccurrences() { return Occurrences != null ? Occurrences : new List<EventOccurrence>(); }

        private List<RecurringEventOccurrence> RecurringOccurrences;
        public List<RecurringEventOccurrence> getRecurringOccurrences(){
            return RecurringOccurrences != null ? RecurringOccurrences : new List<RecurringEventOccurrence>(); 
        }

        private List<EventBlackout> Blackouts;

		public List<EventBlackout> getBlackouts()
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
