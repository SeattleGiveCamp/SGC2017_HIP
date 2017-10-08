using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using HIP.MobileAppService.Models.Repositories;


namespace HIP.MobileAppService.Models
{
	public class EventCheckInRepository : IEventCheckInRepository
	{
		public EventCheckInModel Get(string id)
		{
			return null;
		}

		public IEnumerable<EventCheckInModel> GetAll()
		{
			return null;
		}

		public void Add(EventCheckInModel eventModel)
		{
		}
	}
}
