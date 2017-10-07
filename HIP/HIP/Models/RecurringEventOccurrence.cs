using System;
namespace HIP.Models
{
	public class RecurringEventOccurrence : EventOccurrence
	{
		public DayOfWeek RecurringDay { get; set; }

		public RecurringEventOccurrence(TimeSpan hourDuration, TimeSpan eventDuration, DayOfWeek day) : base(hourDuration, eventDuration)
		{
			RecurringDay = day;
		}
	}
}
