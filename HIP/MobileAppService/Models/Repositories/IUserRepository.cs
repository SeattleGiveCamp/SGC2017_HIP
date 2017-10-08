using System;
using System.Collections.Generic;

namespace HIP.MobileAppService.Models
{
    public interface IUserRepository
    {
        void Add(UserModel item);
        void Update(UserModel item);
        bool Remove(string email);
        UserModel Get(string email);
        IEnumerable<UserModel> GetAll();
    }
}
