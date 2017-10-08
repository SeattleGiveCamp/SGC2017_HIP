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
        public List<ProgramType> ProgramCategories { get; set; }

        //TODO remove, just to mock
        public Event()
        {
        }

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
