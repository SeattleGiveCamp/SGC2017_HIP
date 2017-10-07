using System;
using System.Collections.Generic;
using System.Text;

namespace HIP.Models
{
    class Event
    {
        public string Name { get; }
        public string Description { get; }
        public Boolean IsRecurring { get; }

        public DateTime NextTime { get; }  //TODO: Currently statically setting these values. Need to write logic to handle these correctly
        public Double DurationInHours { get; }

        private DateTime startTime;
        private DateTime endTime;

        //For a single-time event
        public Event(string name, string description, DateTime singleEventDate, Double durtionInHours)
        {
            Name = name;
            Description = description;
            IsRecurring = false;

            //TODO: Currently statically setting these values. Need to write logic to handle these correctly
            NextTime = singleEventDate;
            DurationInHours = durtionInHours;
        }

        //For a recurring event
        
    }
}
