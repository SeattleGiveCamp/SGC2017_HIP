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
        public Boolean IsRecurring { get; set; }
        public string Date { get; set; } //TODO mock for date
        public DateTime NextTime { get; }  //TODO: Currently statically setting these values. Need to write logic to handle these correctly
        public Double DurationInHours { get; }

        private DateTime startTime;
        private DateTime endTime;

        //TODO remove, just to mock
        public Event()
        {
        }

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
