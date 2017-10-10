using System;
using System.Collections.Generic;

namespace HIP.MobileAppService.Models.Repositories
{
    public interface IEventCheckInRepository
    {
        void Add(EventCheckInModel item);
		IEnumerable<EventCheckInModel> GetAll();
        List<EventCheckInModel> GetBetweenDates(DateTime startDate, DateTime endDate);
	}
}
