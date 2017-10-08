using System;
using System.Collections.Generic;

namespace HIP.MobileAppService.Models.Repositories
{
    public interface IEventCheckInRepository
    {
        void Add(EventCheckInModel item);
		EventCheckInModel Get(string email);
		IEnumerable<EventCheckInModel> GetAll();
    }
}
