using System;
namespace HIP.Models
{
	public class EventOccurrence
	{
		public TimeSpan HourDuration { get; set; }
		public TimeSpan EventDuration { get; set; }

		public EventOccurrence(TimeSpan hourDuration, TimeSpan eventDuration)
		{
			HourDuration = hourDuration;
			EventDuration = eventDuration;
		}
	}
}
