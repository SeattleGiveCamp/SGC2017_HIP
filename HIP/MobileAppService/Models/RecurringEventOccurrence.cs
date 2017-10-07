using System;
namespace HIP.MobileAppService.Models
{
	public class RecurringEventOccurrence : EventOccurrence
	{
		public DateTime RecurrenceStart { get; set; }
		public DateTime RecurrenceEnd { get; set; }
		public DayOfWeek RecurringDay { get; set; }

		public RecurringEventOccurrence(DateTime startTime, DateTime endTime, DayOfWeek day, DateTime recurrenceStart, DateTime recurrenceEnd) : base(startTime, endTime)
		{
			RecurringDay = day;
            RecurrenceStart = recurrenceStart;
            RecurrenceEnd = recurrenceEnd;
		}
	}
}
