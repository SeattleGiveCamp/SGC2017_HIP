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

		public IEnumerable<EventCheckInModel> GetAll()
		{
            return new HIPContext().EventCheckIns.ToList();
		}

		public void Add(EventCheckInModel checkIn)
		{
			using (var db = new HIPContext())
			{			
                db.EventCheckIns.Add(checkIn);
				db.SaveChanges();
			}
		}
	}
}
