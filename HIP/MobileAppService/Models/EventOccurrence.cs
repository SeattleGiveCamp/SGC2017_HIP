using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIP.MobileAppService.Models
{
	public class EventOccurrence
	{
        public int Id { get; set; }

        [ForeignKey("EventModel")]
        public string EventModelId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

		public EventOccurrence(DateTime startTime, DateTime endTime)
		{
            Start = startTime;
            End = endTime;
		}
	}
}
