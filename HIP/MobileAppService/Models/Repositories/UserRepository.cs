using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace HIP.MobileAppService.Models
{
	public class UserRepository : IUserRepository
	{
        private static ConcurrentDictionary<string, UserModel> userModels =
			new ConcurrentDictionary<string, UserModel>();

		public UserRepository()
		{
			Add(new UserModel { Email = "test@test1.com", FirstName = "Firs 1", LastName = "Last 1" });
			Add(new UserModel { Email = "test@test2.com", FirstName = "Firs 2", LastName = "Last 2" });
			Add(new UserModel { Email = "test@test3.com", FirstName = "Firs 3", LastName = "Last 3" });
		}

		public UserModel Get(string id)
		{
			return userModels[id];
		}

		public IEnumerable<UserModel> GetAll()
		{
			return userModels.Values;
		}

		public void Add(UserModel user)
		{
			userModels[user.Email] = user;
		}

		public UserModel Find(string id)
		{
			UserModel user;
			userModels.TryGetValue(id, out user);

			return user;
		}

		public UserModel Remove(string id)
		{
			UserModel user;
            userModels.TryRemove(id, out user);

			return user;
		}

		public void Update(UserModel user)
		{
			userModels[user.Email] = user;
		}
	}
}
