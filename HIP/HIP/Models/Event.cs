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
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
        //TODO: actually populate this
        public List<ProgramType> ProgramCategories { get; set; }

        public Event()
        {}

		//For a single-time event
		public Event(string id, string name, string description, DateTime eventStart, DateTime eventEnd, List<ProgramType> programTypes)
		{
            Id = id;
            Name = name;
			Description = description;
            ProgramCategories = programTypes;
		}


		//For a recurring event
		public Event(string id, string name, string description, DateTime eventStart, DateTime eventEnd, List<ProgramType> programTypes, DateTime recurrenceStart, DateTime recurrenceEnd, DayOfWeek occurrenceDay)
		{
			Id = id;
			Name = name;
			Description = description;
            ProgramCategories = programTypes;
        }


	}
}
