using System;
using System.Collections.Generic;

namespace HIP.MobileAppService.Models
{
    public interface IEventRepository
    {
        void Add(EventModel item);
        void Update(EventModel item);
        EventModel Remove(string email);
		EventModel Get(string email);
        EventModel GetBefore(DateTime date);
		IEnumerable<EventModel> GetAll();
    }
}
