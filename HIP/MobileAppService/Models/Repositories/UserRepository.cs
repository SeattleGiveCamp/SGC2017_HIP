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
        }

		public UserModel Get(string id)
		{
            using (var db = new HIPContext())
            {
                var users = db.Users
                    .Where(b => b.Email == id)
                    .ToList();

                return users.ElementAt(0);
            }
        }

		public IEnumerable<UserModel> GetAll()
		{
            using (var db = new HIPContext())
            {
                var users = db.Users
                    .ToList();

                return users;
            }
        }

		public void Add(UserModel user)
		{
            using (var db = new HIPContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

		public bool Remove(string id)
		{
            return true;
		}

		public void Update(UserModel user)
		{
            using (var db = new HIPContext())
            {
                var events = db.Users.Attach(user);
                db.SaveChanges();
            }
        }
	}
}
