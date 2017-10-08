using System;
namespace HIP.Models
{
	public class EventCheckInModel
	{
		//public String Id { get; set; }
		public String UserEmail { get; set; }
		public String ParentUserEmail { get; set; }
		public String EventId { get; set; }
		public Double HourCount { get; set; }
		public DateTime CheckinDate { get; set; }

		public EventCheckInModel()
		{ }

		public EventCheckInModel(String userEmail, String parentUserEmail, String eventId, Double hourCount, DateTime checkinDate)
		{
			//Id = id;
			UserEmail = userEmail;
			ParentUserEmail = parentUserEmail;
			EventId = eventId;
			HourCount = hourCount;
			CheckinDate = checkinDate;
		}

	}
}
