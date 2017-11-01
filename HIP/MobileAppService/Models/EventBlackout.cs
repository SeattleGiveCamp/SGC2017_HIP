using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIP.MobileAppService.Models
{
    public class EventBlackout
    {
        public TimeSpan BlackoutTime { get; set; }

        public int Id { get; set; }

        [ForeignKey("EventModel")]
        public string EventModelId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public EventBlackout(){}
        public EventBlackout(DateTime startTime, DateTime endTime)
        {
            Start = startTime;
            End = endTime;
        }

    }
}
