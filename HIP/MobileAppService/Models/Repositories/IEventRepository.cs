using System;
using System.Collections.Generic;

namespace HIP.MobileAppService.Models
{
    public interface IEventRepository
    {
        void Add(EventModel item);
        void Update(EventModel item);
        bool Remove(string id);
		EventModel Get(string id);
		IEnumerable<EventModel> GetAll();
    }
}
