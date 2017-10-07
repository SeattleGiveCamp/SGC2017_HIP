using System;
namespace HIP.Models
{
    public class EventBlackout
    {
		public TimeSpan BlackoutTime { get; set; }

		public EventBlackout(TimeSpan blackoutTime)
		{
			BlackoutTime = blackoutTime;
		}

	}
}
