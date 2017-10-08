using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIP.MobileAppService.Models
{
	public class RecurringEventOccurrence
	{
        public int Id { get; set; }
        [ForeignKey("EventModel")]
        public string EventModelId { get; set; }
        public DateTime RecurrenceStart { get; set; }
		public DateTime RecurrenceEnd { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
		public DayOfWeek RecurringDay { get; set; }

		public RecurringEventOccurrence(TimeSpan startTime, TimeSpan endTime, DayOfWeek day, DateTime recurrenceStart, DateTime recurrenceEnd)
		{
			RecurringDay = day;
            RecurrenceStart = recurrenceStart;
            RecurrenceEnd = recurrenceEnd;
            StartTime = startTime;
            EndTime = endTime;
		}
	}
}
