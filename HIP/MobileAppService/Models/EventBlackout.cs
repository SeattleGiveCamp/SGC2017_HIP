using System;
namespace HIP.MobileAppService.Models
{
    public class EventBlackout: EventOccurrence
    {
		public TimeSpan BlackoutTime { get; set; }

        public EventBlackout(DateTime startTime, DateTime endTime): base(startTime, endTime)
        {}

	}
}
