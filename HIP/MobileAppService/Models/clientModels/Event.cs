using System;
using System.Collections.Generic;
using System.Text;
using HIP.MobileAppService.Models;

namespace HIP.MobileAppService.Models.ClientModels
{
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
		public List<ProgramType> ProgramCategories { get; set; }

		public Event()
        {
        }

		public Event(string id, string name, string description, DateTime eventStart, DateTime eventEnd, List<ProgramType> programCategories)
		{
            Id = id;
            Name = name;
			Description = description;
            Start = eventStart;
            End = eventEnd;
            ProgramCategories = programCategories;

		}


	}
}
