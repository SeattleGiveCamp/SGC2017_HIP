using System;
namespace HIP.MobileAppService.Models
{
	public class EventOccurrence
	{
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

		public EventOccurrence(DateTime startTime, DateTime endTime)
		{
            Start = startTime;
            End = endTime;
		}
	}
}
